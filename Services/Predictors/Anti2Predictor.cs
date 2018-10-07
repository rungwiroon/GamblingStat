using Services.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Services.Predictors
{
    public class Anti2Predictor : IPredictor
    {
        public GameState Predict(IEnumerable<GameState> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index <= 2)
                return currentState;

            var score = from r in gameStates.ElementAt(index - 1).Predictions.Find(Constants.SameDiffPredictionName).Bind(x => x.Result)
                        from s in currentState.Predictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score)
                        select r == Result.Lose
                        ? s == Score.Dragon ? Score.Tiger : Score.Dragon
                        : s;

            var newGameState = currentState;

            score.IfSome(x =>
            {
                newGameState = new GameState
                (
                    index,
                    currentState.ActualScore,
                    currentState.Predictions.Select(p => (p.Value.Name, p.Value.Score))
                        .Append((Constants.Anti2PredictionName, x))
                        .Append((Constants.InvertedAnti2PredictionName, Helper.InvertScoreMapper(x)))
                );
            });

            //Debug.WriteLine("Anti2\t" + newGameState);

            return newGameState;
        }
    }
}
