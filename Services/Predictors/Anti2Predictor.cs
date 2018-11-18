using LanguageExt;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Predictors
{
    public class Anti2Predictor : IPredictor
    {
        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index <= 2)
                return currentState;

            var score = from r in gameStates.ElementAt(index - 1).ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(x => x.Result)
                        from s in currentState.ScorePredictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score)
                        select r == Result.Lose
                        ? s == Score.Dragon ? Score.Tiger : Score.Dragon
                        : s;

            return score.Match(x =>
            {
                return new GameStateOutput
                (
                    index,
                    currentState.ActualScore,
                    currentState.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                        .Append((Constants.Anti2PredictionName, x))
                        .Append((Constants.InvertedAnti2PredictionName, Helper.InvertScoreMapper(x)))
                );
            }, () => currentState);
        }
    }
}
