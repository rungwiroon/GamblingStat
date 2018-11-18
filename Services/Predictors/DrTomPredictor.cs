using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;
using static LanguageExt.Prelude;
using Services.Domain;

namespace Services.Predictors
{
    public class DrTomPredictor : IPredictor
    {
        private const int Size = 4;

        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentState = gameStates.ElementAt(index);

            if (index < Size - 1)
                return currentState;

            var length = gameStates.Count();
            var circuit = CalculateCircuit(gameStates, length - Size);
            var previousStates = gameStates.Reverse().Skip(1).Take(Size)
                .ToList();
            var sign = previousStates[0].ResultPrediction
                .Map(x => x.Circuit == circuit ? DrTomSign.Plus : DrTomSign.Minus);
            var signChanged = CalculateSignChanged(sign, previousStates);

            var oneTwo = CalculateOneTwo(sign, previousStates[0].ResultPrediction);

            var signHistory = new Option<DrTomSign>[] { sign }.Concat(
                                from pStats in previousStates
                                from resultP in pStats.ResultPrediction
                                select resultP.Sign);

            var isDifferentSignHistory = false;

            if (signHistory.Take(Size).All(x => x.IsSome))
            {
                isDifferentSignHistory = signHistory.Take(Size)
                    .Zip(signHistory.Skip(1))
                    .All(x => x.Item1 != x.Item2);
            }
            
            //var cTempSign = 

            var c = from p1ResultP in previousStates[0].ResultPrediction
                    from p1Sign in p1ResultP.Sign
                    from cSign in sign
                    from ot in oneTwo
                    select ot == DrTom12.Two && p1Sign != cSign
                        ? DrTomC.CPlus
                        : ot == DrTom12.Two && p1Sign == cSign
                            ? DrTomC.CMinus
                            : signHistory.Last().IsNone && isDifferentSignHistory
                                && sign.IsSome
                                ? DrTomC.CPlus
                                : Option<DrTomC>.None;

            Option<Result> wl;

            if(c.IsNone)
            {
                if (oneTwo.IsNone)
                {
                    var previousSigns = from ps in previousStates.Take(3)
                                        from rp in ps.ResultPrediction
                                        from s in rp.Sign
                                        select s;

                    if(previousSigns.Count() == 3)
                    {
                        if (previousSigns.All(x => x == DrTomSign.Minus || x == DrTomSign.Plus))
                            wl = Result.Win;
                        else if ((previousSigns.Skip(1).All(x => x == DrTomSign.Minus)
                            && previousSigns.First() == DrTomSign.Plus)
                            || (previousSigns.Skip(1).All(x => x == DrTomSign.Plus)
                            && previousSigns.First() == DrTomSign.Minus)
                            wl = Result.Lose;
                    }
                }
                else
                {

                }
            }
            else
            {

            }

            var resultPrediction = new DrTomPrediction(
                circuit,
                sign, signChanged,
                oneTwo, None,
                c.Bind(x => x), None,
                None);

            return new GameStateOutput(
                index,
                currentState.ActualScore,
                currentState.ScorePredictions,
                resultPrediction
                );
        }

        private Option<DrTomCircuit> CalculateCircuit(IEnumerable<GameStateOutput> gameStates, int skipCount)
        {
            var results = gameStates.Skip(skipCount).ToList();
            var winCount = results.Count(r => r.ActualResult == Result.Win);
            var loseCount = results.Count(r => r.ActualResult == Result.Lose);
            var circuit = (winCount == loseCount || winCount == 0 || loseCount == 0)
                ? DrTomCircuit.Balance
                : DrTomCircuit.Imbalance;

            return circuit;
        }

        //private Option<DrTomSign> CalculateSign(IEnumerable<GameStateOutput> gameStates, int skipCount)
        //{
        //    var previousStats = gameStates.Reverse().Skip(1).Take(Size)
        //        .ToList();
        //    var sign = previousStats[0].ResultPrediction
        //        .Map(x => x.Circuit == circuit ? DrTomSign.Plus : DrTomSign.Minus);
        //}

        private Option<bool> CalculateSignChanged(Option<DrTomSign> currentSign, List<GameStateOutput> previousStates)
        {
            var signChanged =
                    from p1ResultP in previousStates[0].ResultPrediction
                    from p1Sign in p1ResultP.Sign
                    from cSign in currentSign
                    select p1Sign != cSign;

            signChanged = previousStates[1].ResultPrediction.Bind(x => x.Sign)
                .Match(p2Sign =>
                {
                    return from p1ResultP in previousStates[0].ResultPrediction
                           from p1Sign in p1ResultP.Sign
                           from sChanged in signChanged
                           select sChanged && p2Sign == p1Sign;
                }, () => signChanged);

            return signChanged;
        }

        private Option<DrTom12> CalculateOneTwo(Option<DrTomSign> currentSign, Option<DrTomPrediction> previousPrediction)
        {
            var oneTwo = from pp in previousPrediction
                         from pSignChanged in pp.SignChanged
                         from pSign in pp.Sign
                         where pSignChanged
                         select currentSign == pSign ? DrTom12.One : DrTom12.Two;

            return oneTwo;
        }
    }
}
