using LanguageExt;
using GamblingStat.Services.Domain;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace GamblingStat.Services.Predictors
{
    public class Anti2Predictor : IPredictor
    {
        public IObservable<GameStateOutput> Predict(IObservable<GameStateOutput> gameStates)
        {
            return gameStates
                .Scan(
                    new Lst<GameStateOutput>(),
                    (acc, currItem) =>
                    {
                        if (currItem.Index > 2)
                            currItem = Calculate(acc.Last(), currItem);

                        return acc.Add(currItem);
                    })
                .Select(list => list.Last());

            static GameStateOutput Calculate(GameStateOutput prevItem, GameStateOutput currItem)
            {
                var score = from r in prevItem.ScorePredictions.Find(Constants.SameDiffPredictionName).Bind(x => x.Result)
                            from s in currItem.ScorePredictions.Find(Constants.SameDiffPredictionName).Map(x => x.Score)
                            select r == Result.Lose
                                ? s == Score.Dragon ? Score.Tiger : Score.Dragon
                                : s;

                return score.Match(
                    Some: x =>
                        new GameStateOutput
                        (
                            currItem.Index,
                            currItem.ActualScore,
                            currItem.BetScore,
                            currItem.ScorePredictions.Select(p => (p.Value.Name, p.Value.Score))
                                .Append((Constants.Anti2PredictionName, x))
                        ),
                    None: () => currItem);
            }
        }
    }
}
