using LanguageExt;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

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

        public GameStateOutputGroup Predict(
            IEnumerable<GameStateInput> scores, 
            int tableSize,
            int scorePredictorLookBehide,
            int predictionLimit = int.MaxValue)
        {
            var scoresWithNextScore = scores
                .Skip(scores.Count() - scorePredictorLookBehide)
                .Append(new GameStateInput(None, None));

            var scoreResult = Enumerable.Range(0, (int)Math.Pow(2, tableSize - 1))
                .Select(x => (gs: PredictScore3(scoresWithNextScore, MapToScores(x, tableSize)), mv: x))
                .Select(x => (gameState: x.gs, stat: StatService.Calculate(x.gs.Where(gs => gs.ActualScore.IsSome), x.mv)));

            var resultResult = PredictResult(scores);

            return new GameStateOutputGroup(
                scoreResult.Select(r => new GameStateOutputDetail(r.gameState, r.stat)),
                resultResult);
        }

        public IEnumerable<GameStateOutput> PredictScore(IEnumerable<GameStateInput> gameStates, IEnumerable<Score> mappingScores)
        {
            var scoresWithNextScore = gameStates
                .Append(new GameStateInput(None, None));

            return PredictScore3(scoresWithNextScore, mappingScores);
        }

        public IEnumerable<GameStateOutput> PredictScore(IEnumerable<GameStateInput> gameStates, int mappingValue, int tableSize)
        {
            var scoresWithNextScore = gameStates.Append(new GameStateInput(None, None));

            return PredictScore3(scoresWithNextScore, MapToScores(mappingValue, tableSize));
        }

        private IEnumerable<GameStateOutput> PredictScore3(IEnumerable<GameStateInput> gameStates, IEnumerable<Score> mappingScores)
        {
            var infMappingScores = InfiniteScores(mappingScores);
            var result1 = gameStates.Zip(infMappingScores, (x, y) => (gameState: x, predictScore: y))
                .Select((p, index) => new GameStateOutput(index, p.gameState.ActualScore, p.gameState.BetScore,
                    CreateMappingTablePrediction(p.predictScore)));

            var result2 = _predictors.Aggregate(result1, (items, p) => items.Select((gs, i) => p.Predict(items, gs.Index)).ToList());

            return result2;
        }

        private IEnumerable<(string, Score)> CreateMappingTablePrediction(Option<Score> score)
        {
            return score.Match(s =>
                new (string, Score)[]
                    {
                        (
                            Constants.MappingTablePredctionName,
                            s
                        )
                    }
                , () => new (string, Score)[0]);
        }

        private IEnumerable<GameStateOutput> PredictResult(IEnumerable<GameStateInput> scores)
        {
            var outputs = scores.Select((x, i) => new GameStateOutput(i, x.ActualScore, x.BetScore)).ToList();

            for (int i = 0; i < outputs.Count; i++)
            {
                var output = _resultPredictor.Predict(outputs, i);
                outputs[i] = output;
            }

            return outputs;
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
