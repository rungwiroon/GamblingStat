using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageExt;
using GamblingStat.Services.Domain;
using Stateless;
using static LanguageExt.Prelude;

namespace GamblingStat.Services.Predictors
{
    public class DrTom3Predictor : IPredictor
    {
        public StateMachine<DrTom3State, DrTom3Trigger> StateMachine { get; private set; }

        //private const int InitialOneTwoSize = 3;
        private const int OneCheckSize = 4;
        //private const int CheckCSize = 2;

        private const int StartIndex = 12;

        public DrTom3Predictor()
        {
            StateMachine = new StateMachine<DrTom3State, DrTom3Trigger>(DrTom3State.One);
            StateMachine.Configure(DrTom3State.One)
                .Permit(DrTom3Trigger.DifferentSign, DrTom3State.SignChanged)
                .Ignore(DrTom3Trigger.SameSign);

            StateMachine.Configure(DrTom3State.SignChanged)
                .Permit(DrTom3Trigger.SameSign, DrTom3State.One)
                .Permit(DrTom3Trigger.DifferentSign, DrTom3State.Two);

            StateMachine.Configure(DrTom3State.Two)
                .Permit(DrTom3Trigger.SameSign, DrTom3State.CMinus)
                .Permit(DrTom3Trigger.DifferentSign, DrTom3State.CPlus);

            StateMachine.Configure(DrTom3State.CMinus)
                .Ignore(DrTom3Trigger.SameSign)
                .Permit(DrTom3Trigger.DifferentSign, DrTom3State.SignChanged);

            StateMachine.Configure(DrTom3State.CPlus)
                .Permit(DrTom3Trigger.SameSign, DrTom3State.CMinus)
                .Ignore(DrTom3Trigger.DifferentSign);
        }

        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            var currentGameState = gameStates.ElementAt(index);

            if (index < StartIndex)
                return currentGameState;

            var previousStates = gameStates.Take(index + 1).Reverse().Take(OneCheckSize)
                .ToList();

            // is sign changed
            var signChanged =   from ar1 in currentGameState.ActualResult
                                from ar2 in previousStates[1].ActualResult
                                from rp in previousStates[1].ResultPrediction
                                where ar1 != ar2
                                select rp.SignChanged.Match(sc => sc + 1, () => 1);

            var currentState = StateMachine.State;

            signChanged.Match(
                x => StateMachine.Fire(DrTom3Trigger.DifferentSign),
                () => StateMachine.Fire(DrTom3Trigger.SameSign));

            var state = MapState(StateMachine.State, currentState);

            Option<Result> resultPrediction = None;

            var finalStatus = state;

            if (state == DrTom2State.Two)
            {
                var lastC = from rp in previousStates[1].ResultPrediction
                            from ch in rp.CHistory
                            select ch;

                finalStatus = lastC.Match(
                    Some: x =>
                    {
                        return x == DrTomC.CMinus
                            ? DrTom2State.CMinus
                            : DrTom2State.CPlus;
                    },
                    None: () => DrTom2State.CMinus);
            }

            switch (finalStatus)
            {
                case DrTom2State.One:
                case DrTom2State.CMinus:
                    resultPrediction = currentGameState.ActualResult;
                    break;
                case DrTom2State.CPlus:
                    resultPrediction = currentGameState.ActualResult.Map(r =>
                    r == Result.Lose
                    ? Result.Win
                    : Result.Lose);
                    break;
            }

            return new GameStateOutput(
                    currentGameState.Index,
                    currentGameState.ActualScore,
                    currentGameState.BetScore,
                    currentGameState.ScorePredictions,
                    new DrTom2Prediction(
                        None, MapToC(finalStatus), state, resultPrediction));
        }

        private DrTom2State MapState(DrTom3State state) =>
            state switch
            {
                DrTom3State.CMinus => DrTom2State.CMinus,
                DrTom3State.CPlus => DrTom2State.CPlus,
                DrTom3State.One => DrTom2State.One,
                DrTom3State.Two => DrTom2State.Two,
                _ => DrTom2State.One,
            };

        private DrTom2State MapState(DrTom3State state, DrTom3State previousState) =>
            state switch
            {
                DrTom3State.CMinus => DrTom2State.CMinus,
                DrTom3State.CPlus => DrTom2State.CPlus,
                DrTom3State.One => DrTom2State.One,
                DrTom3State.SignChanged => MapState(previousState),
                DrTom3State.Two => DrTom2State.Two,
                _ => DrTom2State.One,
            };

        private Option<DrTomC> MapToC(DrTom2State finalStatus) =>
            finalStatus switch
            {
                DrTom2State.CMinus => DrTomC.CMinus,
                DrTom2State.CPlus => DrTomC.CPlus,
                _ => None,
            };
    }
}
