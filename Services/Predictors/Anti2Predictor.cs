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

            var score = from x in gameStates.ElementAt(index - 1).Predictions[Constants.SameDiffPredictionName].Result
                        from y in currentState.Predictions[Constants.SameDiffPredictionName].Score
                        select x == Result.Lose
                        ? y == Score.Dragon ? Score.Tiger : Score.Dragon
                        : y;

            var newGameState = new GameState
            (
                index,
                currentState.ActualScore,
                currentState.Predictions.Select(p => (p.Value.Name, p.Value.Score))
                    .Append((Constants.Anti2PredictionName, score))
                    .Append((Constants.InvertedAnti2PredictionName, score.Map(Helper.InvertScoreMapper)))
            );

            //Debug.WriteLine("Anti2\t" + newGameState);

            return newGameState;
        }
    }
}
