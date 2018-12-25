using LanguageExt;
using GamblingStat.Services.Domain;
using GamblingStat.Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamblingStat.Services
{
    public class StatService
    {
        public static Stat Calculate(IEnumerable<GameStateOutput> gameStates, int mappingValue)
        {
            var predictionStats = Constants.AllPredictionNames
                .Select(pn => (name: pn, results: Filter(gameStates.Select(gs => gs.ScorePredictions.Find(pn).Bind(p => p.Result)))))
                .Select(pr => Calculate(pr.name, pr.results));

            return new Stat(mappingValue, predictionStats);

            IEnumerable<Result> Filter(IEnumerable<Option<Result>> rs)
            {
                return rs
                    .Where(r => r.IsSome)
                    .Select(r => r.IfNone(Result.Lose));
            }
        }

        public static PredictionStat Calculate(string name, IEnumerable<Result> results)
        {
            var winRate = (int)(results
                .Sum(r => r == Result.Win ? 1 : 0)
                / (float)results.Count() * 100);

            var wrongList = new List<(int lastIndex, int wrongCount)>()
            {
                (int.MinValue, 0)
            };

            var wrongCount = results
                .Select((r, i) => new { Result = r, Index = i })
                .Where(r => r.Result == Result.Lose)
                .Aggregate(wrongList, (acc, res) =>
                {
                    if(res.Index - acc.Last().lastIndex > 1)
                    {
                        acc.Add((res.Index, 1));
                    }
                    else
                    {
                        acc.Add((res.Index, acc.Last().wrongCount + 1));
                    }

                    return acc;
                });

            return new PredictionStat(
                name,
                winRate, 
                wrongCount.Where(wc => wc.wrongCount == 1).Count(),
                wrongCount.Where(wc => wc.wrongCount == 2).Count(),
                wrongCount.Where(wc => wc.wrongCount > 2).Count(),
                wrongCount.Max(wc => wc.wrongCount));
        }
    }
}
