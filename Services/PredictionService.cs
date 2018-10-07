using LanguageExt;
using Services.Domain;
using Services.Predictors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PredictionService
    {
        private IEnumerable<IPredictor> _predictors;

        public PredictionService(IEnumerable<IPredictor> predictors)
        {
            _predictors = predictors;
        }

        public IEnumerable<(IEnumerable<GameState> gameStates, Stat stat)> Predict(
            IEnumerable<Score> scores, 
            int tableSize, 
            int predictionLimit = int.MaxValue)
        {
            var scoresWithNextScore = scores.Select(s => Option<Score>.Some(s)).Concat(new Option<Score>[] { Option<Score>.None });

            var result = Enumerable.Range(0, (int)Math.Pow(2, tableSize))
                .Select(x => (gs: Predict3(scoresWithNextScore, MapToScores(x, tableSize)), mv: x))
                .Select(x => (gameState: x.gs, stat: StatService.Calculate(x.gs.Where(gs => gs.ActualScore.IsSome), x.mv)));

            return result;
        }

        public IEnumerable<GameState> Predict2(IEnumerable<Score> actualScores, IEnumerable<Score> mappingScores)
        {
            var scoresWithNextScore = actualScores.Select(s => Option<Score>.Some(s))
                .Concat(new Option<Score>[] { Option<Score>.None });

            return Predict3(scoresWithNextScore, mappingScores);
        }

        public IEnumerable<GameState> Predict2(IEnumerable<Score> actualScores, int mappingValue, int tableSize)
        {
            var scoresWithNextScore = actualScores.Select(s => Option<Score>.Some(s))
                .Concat(new Option<Score>[] { Option<Score>.None });

            return Predict3(scoresWithNextScore, MapToScores(mappingValue, tableSize));
        }

        private IEnumerable<GameState> Predict3(IEnumerable<Option<Score>> actualScores, IEnumerable<Score> mappingScores)
        {
            var infMappingScores = InfiniteScores(mappingScores);
            var result1 = actualScores.Zip(infMappingScores, (x, y) => (actualScore: x, predictScore: y))
                .Select((p, index) => new GameState(index, p.actualScore, p.predictScore));

            var result2 = _predictors.Aggregate(result1, (items, p) => items.Select((gs, i) => p.Predict(items, gs.Index)).ToList());

            return result2;
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
            yield return Option<Score>.None;

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
