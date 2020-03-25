using System;
using System.Linq;
using LanguageExt;
using GamblingStat.Services.Domain;
using System.Reactive.Linq;

namespace GamblingStat.Services.Predictors
{
    public class Anti12Predictor : IPredictor
    {
        public IObservable<GameStateOutput> Predict(IObservable<GameStateOutput> gameStates)
        {
            return gameStates
                .Scan(
                    new Lst<GameStateOutput>(),
                    (acc, currItem) =>
                    {
                        if (currItem.Index > 2)
                            currItem = Calculate(acc[^2], acc[^1], currItem);

                        return acc.Add(currItem);
                    })
                .Select(list => list.Last());

            static GameStateOutput Calculate(GameStateOutput minus2Item, GameStateOutput minus1Item, GameStateOutput currItem)
            {
                var sameDiffPredictResult2 = Option<Result>.Some(Result.Win);
                if (currItem.Index > 3)
                    sameDiffPredictResult2 = minus2Item.ScorePredictions
                        .Find(Constants.SameDiffPredictionName).Bind(x => x.Result);

                var score = from sdpr1 in sameDiffPredictResult2
                            from sdpr2 in minus1Item.ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(x => x.Result)
                            from sdps in currItem.ScorePredictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score)
                            select (sdpr1 == Result.Lose && sdpr2 == Result.Lose)
                            ? sdps
                            : sdps == Score.Dragon ? Score.Tiger : Score.Dragon;

                return score.Match(x =>
                {
                    return new GameStateOutput
                    (
                        currItem.Index,
                        currItem.ActualScore,
                        currItem.BetScore,
                        currItem.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                            .Append((Constants.Anti12PredictionName, x))
                    );
                }, () => currItem);
            }
        }
    }
}
