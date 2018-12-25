using GamblingStat.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStat.Services
{
    public static class Helper
    {
        internal static Func<Score, Score> InvertScoreMapper => s => s == Domain.Score.Dragon ? Domain.Score.Tiger : Domain.Score.Dragon;
        internal static Func<Result, Result> InvertResultMapper => r => r == Domain.Result.Win ? Domain.Result.Lose : Domain.Result.Win;
    }
}
