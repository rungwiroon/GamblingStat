using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Domain
{
    public class GameStateInput
    {
        private Func<bool, Result> resultMapper => b => b ? Result.Win : Result.Lose;

        public Option<Score> ActualScore { get; private set; }

        public Option<Score> BetScore { get; private set; }

        public Option<Result> ActualResult
        {
            get
            {
                return from actualS in ActualScore
                       from betS in BetScore
                       select resultMapper(actualS == betS);
            }
        }

        public GameStateInput(Option<Score> actualScore, Option<Score> betScore)
        {
            ActualScore = actualScore;
            BetScore = betScore;
        }
    }
}
