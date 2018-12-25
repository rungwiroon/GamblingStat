using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamblingStat.Services.Domain
{
    public class Stat
    {
        public int MappingValue { get; private set; }

        public Map<string, PredictionStat> PredictionStats { get; private set; }

        public Stat(
            int mappingValue,
            IEnumerable<PredictionStat> predictionStats)
        {
            MappingValue = mappingValue;
            PredictionStats = new Map<string, PredictionStat>(predictionStats.Select(ps => (ps.Name, ps)));
        }

        public override string ToString()
        {
            //return $"{MappingValue:000}, {MappingTablePredictionStat}, {SameDiffPredictionStat}, {Anti12PredictionStat}, {Anti2PredictionStat}";

            var text = "{MappingValue:000}, ";
            var predictions = PredictionStats.Select(x => x.ToString());

            text += string.Join(", ", predictions);

            return text;
        }
    }
}
