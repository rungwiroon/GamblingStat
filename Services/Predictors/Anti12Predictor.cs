using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;
using Services.Domain;

namespace Services.Predictors
{
    public class Anti12Predictor : IPredictor
    {
        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index <= 2)
                return currentState;

            var sameDiffPredictResult2 = Option<Result>.Some(Result.Win);
            if (index > 3)
                sameDiffPredictResult2 = gameStates.ElementAt(index - 2).ScorePredictions
                    .Find(Constants.SameDiffPredictionName).Bind(x => x.Result);

            var score = from sdpr1 in sameDiffPredictResult2
                        from sdpr2 in gameStates.ElementAt(index - 1).ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(x => x.Result)
                        from sdps in currentState.ScorePredictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score)
                        select (sdpr1 == Result.Lose && sdpr2 == Result.Lose)
                        ? sdps
                        : sdps == Score.Dragon ? Score.Tiger : Score.Dragon;

            return score.Match(x =>
            {
                return new GameStateOutput
                (
                    index,
                    currentState.ActualScore,
                    currentState.BetScore,
                    currentState.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                        .Append((Constants.Anti12PredictionName, x))
                        .Append((Constants.InvertedAnti12PredictionName, Helper.InvertScoreMapper(x)))
                );
            }, () => currentState);
        }
    }
}
