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
        public string Result { get; set; }
        public int? WinRate { get; set; }
        public string DrTom { get; set; }
    }
}
