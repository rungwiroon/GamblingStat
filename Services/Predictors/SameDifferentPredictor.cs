using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;
using Services.Domain;

namespace Services.Predictors
{
    public class SameDifferentPredictor : IPredictor
    {
        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index <= 1)
                return currentState;

            var score = from r in gameStates.ElementAt(index - 1).ScorePredictions.Find(Constants.MappingTablePredctionName).Bind(x => x.Result)
                        from s in currentState.ScorePredictions.Find(Constants.MappingTablePredctionName).Map(x => x.Score)
                        select r == Result.Lose 
                        ? (s == Score.Tiger ? Score.Dragon : Score.Tiger) 
                        : s;

            GameStateOutput newState = currentState;

            return score.Match(x =>
            {
                return new GameStateOutput
                (
                    index,
                    currentState.ActualScore,
                    currentState.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                        .Append((Constants.SameDiffPredictionName, x))
                        .Append((Constants.InvertedSameDiffPredictionName, Helper.InvertScoreMapper(x)))
                );
            }, () => currentState);
        }
    }
}
