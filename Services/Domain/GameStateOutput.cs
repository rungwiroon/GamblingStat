using LanguageExt;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Domain
{
    public class GameStateOutput
    {
        private Func<bool, Result> resultMapper => b => b ? Result.Win : Result.Lose;

        public int Index { get; private set; }

        public Option<Score> ActualScore { get; private set; }

        public Option<Score> BetScore { get; private set; }

        public Option<Result> ActualResult
        {
            get
            {
                return from actualS in ActualScore
                       from betS in BetScore
                       select resultMapper(actualS == betS);
            }
        }

        public Option<Result> PredictionResult { get; private set; }

        public Map<string, PredictionScore> ScorePredictions { get; private set; }

        public Option<DrTom2Prediction> ResultPrediction { get; private set; }

        public GameStateOutput(int index, Option<Score> actualScore)
        {
            Index = index;
            ActualScore = actualScore;
        }
        
        public GameStateOutput(int index, Option<Score> actualScore, Option<Score> mappingTableScore)
            : this(index, actualScore)
        {
            var prediction = mappingTableScore.Map(x =>
            (
                Constants.MappingTablePredctionName,
                new PredictionScore(
                    Constants.MappingTablePredctionName, x, ActualScore.Map(s => resultMapper(s == ActualScore)))
            ));

            ScorePredictions = new Map<string, PredictionScore>(prediction);
        }

        public GameStateOutput(
            int index,
            Option<Score> actualScore,
            IEnumerable<(string name, Score score)> predictionScores)
            : this(index, actualScore)
        {
            var predictions = ScorePredictions.Select(x => x.Value)
                .Concat(predictionScores.Select(ps => 
                    new PredictionScore(ps.name, ps.score, ActualScore.Map(s => resultMapper(ps.score == s)))));

            ScorePredictions = new Map<string, PredictionScore>(predictions.Select(p => (p.Name, p)));
        }

        public GameStateOutput(
            int index,
            Option<Score> actualScore,
            Map<string, PredictionScore> scorePredictions,
            Option<DrTom2Prediction> resultPrediction)
            : this(index, actualScore)
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
