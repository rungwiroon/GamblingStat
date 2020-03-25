using LanguageExt;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace GamblingStat.Services
{
    public class StatService
    {
        private Lst<(int lastIndex, int wrongCount)> wrongList = new Lst<(int lastIndex, int wrongCount)>(
            new (int, int)[] { (int.MinValue, 0) });

        public IObservable<Stat> Calculate(IObservable<GameStateOutput> gameStates, int mappingValue)
        {
            var predictionStats1 = Constants.AllPredictionNames
                .Select(predictionName => gameStates
                    .Select(gameState => (
                        seqNumber: gameState.Index, 
                        name: predictionName, 
                        result: gameState.ScorePredictions.Find(predictionName).Bind(p => p.Result).IfNone(Result.Lose)))
                    .Scan(Option<PredictionStat>.None, (acc, pr) => Calculate(acc, pr.name, pr.seqNumber, pr.result))
                    .Select(ps => ps.IfNoneUnsafe((PredictionStat)null)));

            var predictionStats2 = Observable.Zip(predictionStats1)
                .Select(val => new Stat(mappingValue, val));

            return predictionStats2;
        }

        public PredictionStat Calculate(Option<PredictionStat> lastPredictionStat, string name, int seqNumber, Result newResult)
        {
            return lastPredictionStat
                .Match(
                    Some: val =>
                    {
                        var winRate = (val.WinRate + newResult == Result.Win ? 100f : 0f) / 2;

                        wrongList = UpdateLoseStat(newResult);

                        return new PredictionStat(
                                name,
                                (int)winRate,
                                wrongList.Where(wc => wc.wrongCount == 1).Count(),
                                wrongList.Where(wc => wc.wrongCount == 2).Count(),
                                wrongList.Where(wc => wc.wrongCount > 2).Count(),
                                wrongList.Max(wc => wc.wrongCount));
                    },
                    None: () =>
                    {
                        wrongList = UpdateLoseStat(newResult);

                        return new PredictionStat(
                                name,
                                newResult == Result.Win ? 100 : 0,
                                wrongList.Where(wc => wc.wrongCount == 1).Count(),
                                0,
                                0,
                                wrongList.Max(wc => wc.wrongCount));
                    });

            Lst<(int lastIndex, int wrongCount)> UpdateLoseStat(Result newResult)
            {
                if (newResult == Result.Lose)
                {
                    var (lastIndex, wrongCount) = wrongList.Last();

                    if (seqNumber - lastIndex > 1)
                        return wrongList.Add((seqNumber, 1));
                    else
                        return wrongList.Add((seqNumber, wrongCount + 1));
                }

                return wrongList;
            }
        }
    }
}
