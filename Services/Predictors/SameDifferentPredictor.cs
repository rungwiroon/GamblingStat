using System;
using System.Linq;
using LanguageExt;
using GamblingStat.Services.Domain;
using System.Reactive.Linq;

namespace GamblingStat.Services.Predictors
{
    public class SameDifferentPredictor : IPredictor
    {
        public IObservable<GameStateOutput> Predict(IObservable<GameStateOutput> gameStates)
        {
            return gameStates
                .Scan(
                    new Lst<GameStateOutput>(),
                    (acc, currItem) =>
                    {
                        if (currItem.Index > 1)
                            currItem = Calculate(acc[^2], acc[^1], currItem);

                        return acc.Add(currItem);
                    })
                .Select(list => list.Last());

            static GameStateOutput Calculate(
                GameStateOutput minus2Item, 
                GameStateOutput minus1Item, 
                GameStateOutput currItem)
            {
                var score = from r in minus1Item.ScorePredictions.Find(Constants.MappingTablePredictionName).Bind(x => x.Result)
                            from s in currItem.ScorePredictions.Find(Constants.MappingTablePredictionName).Map(x => x.Score)
                            select r == Result.Lose
                            ? (s == Score.Tiger ? Score.Dragon : Score.Tiger)
                            : s;

                GameStateOutput newState = currItem;

                return score.Match(x =>
                {
                    return new GameStateOutput
                    (
                        currItem.Index,
                        currItem.ActualScore,
                        currItem.BetScore,
                        currItem.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                            .Append((Constants.SameDiffPredictionName, x))
                    );
                }, () => currItem);
            }
        }
    }
}
