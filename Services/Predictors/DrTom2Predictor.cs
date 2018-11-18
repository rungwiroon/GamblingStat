using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;
using static LanguageExt.Prelude;
using Services.Domain;

namespace Services.Predictors
{
    public class DrTom2Predictor : IPredictor
    {
        private const int InitialOneTwoSize = 3;
        private const int OneCheckSize = 4;
        private const int CheckCSize = 2;

        private const int StartIndex = 12;

        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index < StartIndex)
                return currentState;

            var length = gameStates.Count();
            var previousStates = gameStates.Reverse().Take(OneCheckSize)
                .ToList();

            DrTom2Status currentStatus = DrTom2Status.One;

            // if it the first prediction then init with 1
            if(previousStates[1].ResultPrediction.IsNone)
            {
                return new GameStateOutput(
                    currentState.Index,
                    currentState.ActualScore,
                    currentState.ScorePredictions,
                    new DrTom2Prediction(
                        None, None, currentStatus, previousStates[1].ActualResult));
            }

            // is sign changed
            Option<int> signChanged = from ac in currentState.ActualResult
                                      from rp in previousStates[1].ResultPrediction
                                      from pr in rp.Result
                                      where ac != pr
                                      select rp.SignChanged.Match(sc => sc + 1, () => 1);

            var previousStatus = from rp in previousStates[1].ResultPrediction
                                 from pa in rp.Status
                                 select pa;

            // if sign changed
            var state2 = from sc in signChanged
                         from pa in previousStatus
                         select CalculateActualWhenSignChanged(pa);

            // create current actual
            previousStatus.IfSome(pa =>
            {
                currentStatus = state2.IfNone(CalculateActualWhenSignNoChanged(pa));
            });

            // if match with 1 pattern
            if (previousStates.Count >= OneCheckSize)
            {
                if (IsItOnePattern(previousStates.Take(OneCheckSize)
                    .Select(ps => ps.ActualResult.IfNone(Result.Lose))))
                    currentStatus = DrTom2Status.One;
            }

            var finalStatus = currentStatus;

            if(currentStatus == DrTom2Status.Two)
            {
                var lastC = from rp in previousStates[1].ResultPrediction
                            from ch in rp.CHistory
                            select ch;

                finalStatus = lastC.Match(x =>
                {
                    if (x == DrTomC.CMinus)
                        return DrTom2Status.CMinus;
                    else
                        return DrTom2Status.CPlus;
                }, () =>
                {
                    return DrTom2Status.CMinus;
                });
            }

            Option<Result> resultPrediction = None;

            // if 1, C- same as last result
            // if C+ opposite from last result
            switch (finalStatus)
            {
                case DrTom2Status.One:
                case DrTom2Status.CMinus:
                    resultPrediction = currentState.ActualResult;
                    break;
                case DrTom2Status.CPlus:
                    resultPrediction = currentState.ActualResult.Map(r => 
                    r == Result.Lose 
                    ? Result.Win 
                    : Result.Lose);
                    break;
            }

            return new GameStateOutput(
                    currentState.Index,
                    currentState.ActualScore,
                    currentState.ScorePredictions,
                    new DrTom2Prediction(
                        MapSignChanged(currentStatus, signChanged),
                        MapToC(finalStatus),
                        currentStatus,
                        resultPrediction));
        }

        private bool IsItOnePattern(IEnumerable<Result> gameStates)
        {
            var part1 = gameStates.Take(OneCheckSize / 2).ToList();
            var part2 = gameStates.Skip(OneCheckSize / 2).ToList();

            var balance = part1.All(r => r == Result.Win || r == Result.Lose)
                && part2.All(r => r == Result.Win || r == Result.Lose)
                ? true
                : false;

            return balance;
        }

        private DrTom2Status CalculateActualWhenSignNoChanged(
            DrTom2Status previousDrTomStatus)
        {
            if (previousDrTomStatus == DrTom2Status.Two
                || previousDrTomStatus == DrTom2Status.CPlus)
            {
                return DrTom2Status.CMinus;
            }

            else
            {
                return previousDrTomStatus;
            }
        }

        private DrTom2Status CalculateActualWhenSignChanged(
            DrTom2Status previousDrTomStatus)
        {
            if (previousDrTomStatus == DrTom2Status.One
                || previousDrTomStatus == DrTom2Status.CMinus)
                return DrTom2Status.Two;
            else
                return DrTom2Status.CPlus;
        }

        private Option<int> MapSignChanged(DrTom2Status current, Option<int> signChanged)
        {
            switch(current)
            {
                case DrTom2Status.One:
                case DrTom2Status.Two:
                    return 1;
                default:
                    return signChanged;
            }
        }

        private Option<DrTomC> MapToC(DrTom2Status finalStatus)
        {
            switch(finalStatus)
            {
                case DrTom2Status.CMinus:
                    return DrTomC.CMinus;
                case DrTom2Status.CPlus:
                    return DrTomC.CPlus;
                default:
                    return None;
            }
        }
    }
}
