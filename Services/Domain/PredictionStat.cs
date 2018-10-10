using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Domain
{
    public class PredictionStat
    {
        public string Name { get; set; }
        public int WinRate { get; private set; }
        public int Wrong1Count { get; private set; }
        public int Wrong2Count { get; private set; }
        public int Wrong3AndMoreCount { get; private set; }
        public int MaxConsecutiveWrong { get; private set; }

        public PredictionStat(
            string name,
            int winRate, 
            int wrong1Count,
            int wrong2Count,
            int wrong3AndMoreCount,
            int maxConsecutiveWrong)
        {
            Name = name;
            WinRate = winRate;
            Wrong1Count = wrong1Count;
            Wrong2Count = wrong2Count;
            Wrong3AndMoreCount = wrong3AndMoreCount;
            MaxConsecutiveWrong = maxConsecutiveWrong;
        }

        public override string ToString()
        {
            return $"{WinRate:00}% : {Wrong3AndMoreCount},{Wrong2Count},{Wrong1Count}";
        }
    }
}
