using LanguageExt;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Domain
{
    public class PredictionScore
    {
        public string Name { get; set; }

        public Option<Score> Score { get; private set; }

        public Option<Result> Result { get; private set; }

        //public Option<Score> InvertedScore { get; private set; }

        //public Option<Result> InvertedResult { get; private set; }

        //private static Func<Score, Score> invertScoreMapper => s => s == Domain.Score.Dragon ? Domain.Score.Tiger : Domain.Score.Dragon;
        //private static Func<Result, Result> invertResultMapper => r => r == Domain.Result.Win ? Domain.Result.Lose : Domain.Result.Win;

        public PredictionScore(string name, Option<Score> score, Option<Result> result)
        {
            Name = name;
            Score = score;
            Result = result;
            //InvertedScore = Score.Map(invertScoreMapper);
            //InvertedResult = Result.Map(invertResultMapper);
        }

        public override string ToString()
        {
            return $"{Name}:{Score.Map(s => s == Domain.Score.Dragon ? "D" : "T").IfNone(string.Empty)}:{Result}";
        }
    }

    public class GameState
    {
        private Func<bool, Result> resultMapper => b => b ? Result.Win : Result.Lose;
        private Func<Score, Score> invertScoreMapper => s => s == Score.Dragon ? Score.Tiger : Score.Dragon;
        private Func<Result, Result> invertResultMapper => r => r == Result.Win ? Result.Lose : Result.Win;

        public int Index { get; private set; }

        public Option<Score> ActualScore { get; private set; }

        //public Option<Score> MappingTablePredictScore { get; private set; }

        //public Option<Result> MappingTablePredictResult
        //{
        //    get
        //    {
        //        return MappingTablePredictScore.Map(ps => ActualScore == ps)
        //            .Map(resultMapper);
        //    }
        //}

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
                new PredictionScore(Constants.MappingTablePredctionName, x, resultMapper(x == ActualScore))
            ));

            Predictions = new Map<string, PredictionScore>(prediction);
        }

        public GameState(
            int index,
            Option<Score> actualScore,
            IEnumerable<(string name, Option<Score> score)> predictionScores)
            : this(index, actualScore)
        {
            var predictions = Predictions.Select(x => x.Value)
                .Concat(predictionScores.Select(ps => new PredictionScore(ps.name, ps.score, resultMapper(ps.score == ActualScore))));

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
