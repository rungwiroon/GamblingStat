using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingStatWeb2.App.Services
{
    public class GameState
    {
        public int No { get; set; }
        public string ActualScore { get; set; }
        public string BetScore { get; set; }
        public string Result { get; set; }
        public int? WinRate { get; set; }
        public string DrTomResult { get; set; }
        public string DrTomInfo { get; set; }
    }
}
