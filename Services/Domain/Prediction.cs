using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Domain
{
    public class PredictionScore
    {
        public string Name { get; set; }

        public Score Score { get; private set; }

        public Option<Result> Result { get; private set; }

        public PredictionScore(string name, Score score, Option<Result> result)
        {
            Name = name;
            Score = score;
            Result = result;
        }

        public override string ToString()
        {
            var score = Score == Score.Dragon ? "D" : "T";
            return $"{score}-{Result.Match(x => x.ToString(), () => "N/A")}";
        }
    }
}
