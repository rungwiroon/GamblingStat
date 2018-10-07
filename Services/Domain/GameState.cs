using LanguageExt;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Domain
{
    public class GameState
    {
        private Func<bool, Result> resultMapper => b => b ? Result.Win : Result.Lose;
        private Func<Score, Score> invertScoreMapper => s => s == Score.Dragon ? Score.Tiger : Score.Dragon;
        private Func<Result, Result> invertResultMapper => r => r == Result.Win ? Result.Lose : Result.Win;

        public int Index { get; private set; }

        public Option<Score> ActualScore { get; private set; }

        public Map<string, PredictionScore> Predictions { get; private set; }

        public GameState(int index, Option<Score> actualScore)
        {
            Index = index;
            ActualScore = actualScore;
        }
        
        public GameState(int index, Option<Score> actualScore, Option<Score> mappingTableScore)
            : this(index, actualScore)
        {
            var prediction = mappingTableScore.Map(x =>
            (
                Constants.MappingTablePredctionName,
                new PredictionScore(
                    Constants.MappingTablePredctionName, x, ActualScore.Map(s => resultMapper(s == ActualScore)))
            ));

            Predictions = new Map<string, PredictionScore>(prediction);
        }

        public GameState(
            int index,
            Option<Score> actualScore,
            IEnumerable<(string name, Score score)> predictionScores)
            : this(index, actualScore)
        {
            var predictions = Predictions.Select(x => x.Value)
                .Concat(predictionScores.Select(ps => 
                    new PredictionScore(ps.name, ps.score, ActualScore.Map(s => resultMapper(ps.score == s)))));

            Predictions = new Map<string, PredictionScore>(predictions.Select(p => (p.Name, p)));
        }

        public override string ToString()
        {
            //var text = $"{ActualScore}, {MappingTablePredictScore}";
            var predictions = Predictions.Select(x => x.ToString());

            var text = string.Join(", ", predictions);

            return text;
        }
    }
}
