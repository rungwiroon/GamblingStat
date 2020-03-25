using LanguageExt;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;
using System.Reactive.Linq;

namespace GamblingStat.Services
{
    public class PredictionService
    {
        private IEnumerable<IPredictor> _predictors;
        private IPredictor _resultPredictor;

        public PredictionService(
            IEnumerable<IPredictor> predictors,
            IPredictor resultPredcitor)
        {
            _predictors = predictors;
            _resultPredictor = resultPredcitor;
        }

        public IObservable<GameStateOutputGroup> Predict(
            IObservable<GameStateInput> scores,
            int tableSize,
            int scorePredictorLookBehide)
        {
            var scoresWithNextScore = scores
                //.TakeLast(scorePredictorLookBehide)
                //.Skip(scores.Count() - scorePredictorLookBehide)
                .Append(new GameStateInput(None, None));

            var scorePredictionResult1 = Enumerable.Range(0, (int)Math.Pow(2, tableSize - 1))
                .Select(mappingValue =>
                {
                    var gameState = PredictScore3(scoresWithNextScore, MapToScores(mappingValue, tableSize));
                    var statService = new StatService();
                    var stat = statService.Calculate(gameState, mappingValue);

                    return Observable.Zip(gameState, stat, (gs, s) =>  (gameState: gs, stat: s));
                });

            var scorePredictionResult2 = Observable.Zip(scorePredictionResult1);
            var resultPredictionResult = PredictResult(scores);

            return Observable.Zip(
                scorePredictionResult2, 
                resultPredictionResult, 
                (spr, rpr) =>
                    new GameStateOutputGroup(
                        spr.Select(r => new GameStateOutputDetail(r.gameState, r.stat)),
                        rpr));
        }

        public IObservable<GameStateOutput> PredictScore(IObservable<GameStateInput> gameStates, IEnumerable<Score> mappingScores)
        {
            var scoresWithNextScore = gameStates
                .Append(new GameStateInput(None, None));

            return PredictScore3(scoresWithNextScore, mappingScores);
        }

        public IObservable<GameStateOutput> PredictScore(IObservable<GameStateInput> gameStates, int mappingValue, int tableSize)
        {
            var scoresWithNextScore = gameStates.Append(new GameStateInput(None, None));

            return PredictScore3(scoresWithNextScore, MapToScores(mappingValue, tableSize));
        }

        private IObservable<GameStateOutput> PredictScore3(IObservable<GameStateInput> gameStates, IEnumerable<Score> mappingScores)
        {
            var infMappingScores = InfiniteScores(mappingScores);
            var result1 = gameStates.Zip(infMappingScores, (x, y) => new { gameState = x, predictScore = y })
                .Select((p, index) => new GameStateOutput(
                    index, 
                    p.gameState.ActualScore, 
                    p.gameState.BetScore,
                    CreateMappingTablePrediction(p.predictScore)));

            foreach(var predictor in _predictors)
            {
                result1 = predictor.Predict(result1);
            }

            return result1;
        }

        private IEnumerable<(string, Score)> CreateMappingTablePrediction(Option<Score> score)
        {
            return score.Match(s =>
                new (string, Score)[]
                    {
                        (
                            Constants.MappingTablePredictionName,
                            s
                        )
                    }
                , () => new (string, Score)[0]);
        }

        private IObservable<GameStateOutput> PredictResult(IObservable<GameStateInput> scores)
        {
            var outputs1 = scores.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore));
            var outputs2 = _resultPredictor.Predict(outputs1);

            return outputs2;
        }

        private Score[] MapToScores(int number, int digit)
        {
            BitArray b = new BitArray(new int[] { number });
            return b.Cast<bool>()
                .Take(digit)
                .Select(bit => bit ? Score.Dragon : Score.Tiger)
                .ToArray();
        }

        private IEnumerable<Option<Score>> InfiniteScores(IEnumerable<Score> scores)
        {
            yield return None;

            while (true)
            {
                foreach (var score in scores)
                {
                    yield return score;
                }
            }
        }
    }
}
