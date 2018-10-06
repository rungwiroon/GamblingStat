using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingStat.Models
{
    public class ScoreBoardModel
    {
        public int No { get; set; }
        public string ActualScore { get; set; }
        public string BetScore { get; set; }
        public string Result
        {
            get
            {
                if (string.IsNullOrEmpty(ActualScore)
                    || string.IsNullOrEmpty(BetScore))
                    return string.Empty;

                return ActualScore == BetScore ? "W" : "L";
            }
        }
        public int? WinRate { get; set; }
    }
}
