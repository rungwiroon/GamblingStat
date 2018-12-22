using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Domain
{
    public class GameStateOutput : GameStateInput
    {
        private Func<bool, Result> resultMapper => b => b ? Result.Win : Result.Lose;

        public int Index { get; private set; }

        //public Option<Result> PredictionResult { get; private set; }

        public Map<string, PredictionScore> ScorePredictions { get; private set; }

        public Option<DrTom2Prediction> ResultPrediction { get; private set; }

        public GameStateOutput(int index, Option<Score> actualScore, Option<Score> betScore)
            : base(actualScore, betScore)
        {
            Index = index;
            ActualScore = actualScore;
            BetScore = betScore;
        }
        
        //public GameStateOutput(int index, Option<Score> actualScore, Option<Score> betScore, Option<Score> mappingTableScore)
        //    : this(index, actualScore, betScore)
        //{
        //    var prediction = mappingTableScore.Map(x =>
        //    (
        //        Constants.MappingTablePredctionName,
        //        new PredictionScore(
        //            Constants.MappingTablePredctionName, x, ActualScore.Map(s => resultMapper(s == ActualScore)))
        //    ));

        //    ScorePredictions = new Map<string, PredictionScore>(prediction);
        //}

        public GameStateOutput(
            int index,
            Option<Score> actualScore,
            Option<Score> betScore,
            IEnumerable<(string name, Score score)> predictionScores)
            : this(index, actualScore, betScore)
        {
            var predictions = ScorePredictions.Select(x => x.Value)
                .Concat(predictionScores.Select(ps => 
                    new PredictionScore(ps.name, ps.score, ActualScore.Map(s => resultMapper(ps.score == s)))));

            ScorePredictions = new Map<string, PredictionScore>(predictions.Select(p => (p.Name, p)));
        }

        public GameStateOutput(
            int index,
            Option<Score> actualScore,
            Option<Score> betScore,
            Map<string, PredictionScore> scorePredictions,
            Option<DrTom2Prediction> resultPrediction)
            : this(index, actualScore, betScore)
        {
            ScorePredictions = scorePredictions;

            ResultPrediction = resultPrediction;
        }

        public override string ToString()
        {
            //var text = $"{ActualScore}, {MappingTablePredictScore}";
            var predictions = ScorePredictions.Select(x => x.ToString());

            var text = string.Join(", ", predictions);

            return text;
        }
    }
}
