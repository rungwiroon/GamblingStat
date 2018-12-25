using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStat.Services.Domain
{
    public class GameStateInput
    {
        private Func<bool, Result> ResultMapper => b => b ? Result.Win : Result.Lose;

        public Option<Score> ActualScore { get; protected set; }

        public Option<Score> BetScore { get; protected set; }

        public Option<Result> ActualResult
        {
            get
            {
                return from actualS in ActualScore
                       from betS in BetScore
                       select ResultMapper(actualS == betS);
            }
        }

        public GameStateInput(Option<Score> actualScore, Option<Score> betScore)
        {
            ActualScore = actualScore;
            BetScore = betScore;
        }
    }
}
