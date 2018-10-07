using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Services.Domain;

namespace Services.Predictors
{
    public class SameDifferentPredictor : IPredictor
    {
        public GameState Predict(IEnumerable<GameState> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index <= 1)
                return currentState;

            var score = from r in gameStates.ElementAt(index - 1).Predictions.Find(Constants.MappingTablePredctionName).Bind(x => x.Result)
                        from s in currentState.Predictions.Find(Constants.MappingTablePredctionName).Map(x => x.Score)
                        select r == Result.Lose 
                        ? (s == Score.Tiger ? Score.Dragon : Score.Tiger) 
                        : s;

            GameState newState = currentState;

            score.IfSome(x =>
            {
                newState = new GameState
                (
                    index,
                    currentState.ActualScore,
                    currentState.Predictions.Select(p => (p.Value.Name, p.Value.Score))
                        .Append((Constants.SameDiffPredictionName, x))
                        .Append((Constants.InvertedSameDiffPredictionName, Helper.InvertScoreMapper(x)))
                );
            });

            //var newState = new GameState
            //(
            //    index,
            //    currentState.ActualScore,
            //    currentState.Predictions.Select(p => (p.Value.Name, p.Value.Score))
            //        .Append((Constants.SameDiffPredictionName, score))
            //        .Append((Constants.InvertedSameDiffPredictionName, score.Map(Helper.InvertScoreMapper)))
            //);

            //Debug.WriteLine(newState);

            return newState;
        }
    }
}
