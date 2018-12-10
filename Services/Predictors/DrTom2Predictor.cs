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
            var previousStates = gameStates.Take(index + 1).Reverse().Take(OneCheckSize)
                .ToList();

            DrTom2State currentStatus = DrTom2State.One;

            // if it the first prediction then init with 1
            if(previousStates[1].ResultPrediction.IsNone)
            {
                return new GameStateOutput(
                    currentState.Index,
                    currentState.ActualScore,
                    currentState.BetScore,
                    currentState.ScorePredictions,
                    new DrTom2Prediction(
                        None, None, currentStatus, currentState.ActualResult));
            }

            // is sign changed
            Option<int> signChanged = from ar1 in currentState.ActualResult
                                      from ar2 in previousStates[1].ActualResult
                                      from rp in previousStates[1].ResultPrediction
                                      where ar1 != ar2
                                      select rp.SignChanged.Match(sc => sc + 1, () => 1);

            var previousStatus = from rp in previousStates[1].ResultPrediction
                                 from pa in rp.Status
                                 select pa;

            // if sign changed
            var state2 = from sc in signChanged
                         from pa in previousStatus
                         select CalculateStatusWhenSignChanged(pa, sc);

            var signChanged2 = signChanged.IfNone(() =>
            {
                return previousStates[1].ResultPrediction
                       .Match(x => x.SignChanged.IfNone(0), () => 0);
            });

            // create current actual
            previousStatus.IfSome(pa =>
            {
                currentStatus = state2.Match(s => s, () => CalculateStatusWhenSignNoChanged(pa, signChanged2));
            });

            var finalStatus = currentStatus;

            if(currentStatus == DrTom2State.Two)
            {
                var lastC = from rp in previousStates[1].ResultPrediction
                            from ch in rp.CHistory
                            select ch;

                finalStatus = lastC.Match(x =>
                {
                    if (x == DrTomC.CMinus)
                        return DrTom2State.CMinus;
                    else
                        return DrTom2State.CPlus;
                }, () =>
                {
                    return DrTom2State.CMinus;
                });
            }

            Option<Result> resultPrediction = None;

            // if 1, C- same as last result
            // if C+ opposite from last result
            switch (finalStatus)
            {
                case DrTom2State.One:
                case DrTom2State.CMinus:
                    resultPrediction = currentState.ActualResult;
                    break;
                case DrTom2State.CPlus:
                    resultPrediction = currentState.ActualResult.Map(r => 
                    r == Result.Lose 
                    ? Result.Win 
                    : Result.Lose);
                    break;
            }

            return new GameStateOutput(
                    currentState.Index,
                    currentState.ActualScore,
                    currentState.BetScore,
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

        private DrTom2State CalculateStatusWhenSignNoChanged(
            DrTom2State previousDrTomStatus,
            int signChangedCount)
        {
            if (signChangedCount == 2)
            {
                if (previousDrTomStatus == DrTom2State.One)
                    return DrTom2State.CMinus;
            }

            if (previousDrTomStatus == DrTom2State.Two)
                return DrTom2State.One;

            if (previousDrTomStatus == DrTom2State.Two
                || previousDrTomStatus == DrTom2State.CPlus)
            {
                return DrTom2State.CMinus;
            }

            else
            {
                return previousDrTomStatus;
            }
        }

        private DrTom2State CalculateStatusWhenSignChanged(
            DrTom2State previousDrTomStatus,
            int signChangedCount)
        {
            if(signChangedCount == 2)
            {
                if (previousDrTomStatus == DrTom2State.One)
                {
                    return DrTom2State.Two;
                }
            }

            if (previousDrTomStatus == DrTom2State.CMinus)
                return DrTom2State.Two;

            if (signChangedCount == 1)
                return previousDrTomStatus;

            if (previousDrTomStatus == DrTom2State.One
                || previousDrTomStatus == DrTom2State.CMinus)
                return DrTom2State.Two;
            else
                return DrTom2State.CPlus;
        }

        private Option<int> MapSignChanged(DrTom2State current, Option<int> signChanged)
        {
            if (signChanged == 1)
                return signChanged;

            switch(current)
            {
                case DrTom2State.One:
                case DrTom2State.CMinus:
                case DrTom2State.CPlus:
                    return 0;
                default:
                    return signChanged;
            }
        }

        private Option<DrTomC> MapToC(DrTom2State finalStatus)
        {
            switch(finalStatus)
            {
                case DrTom2State.CMinus:
                    return DrTomC.CMinus;
                case DrTom2State.CPlus:
                    return DrTomC.CPlus;
                default:
                    return None;
            }
        }
    }
}
