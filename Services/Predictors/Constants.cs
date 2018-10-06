using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Predictors
{
    public class Constants
    {
        public const string MappingTablePredctionName = "MT";
        public const string SameDiffPredictionName = "SD";
        public const string Anti12PredictionName = "A12";
        public const string Anti2PredictionName = "A2";
        public const string InvertedSameDiffPredictionName = "iSD";
        public const string InvertedAnti12PredictionName = "iA12";
        public const string InvertedAnti2PredictionName = "iA2";

        public static readonly string[] AllPredictionNames = new string[]
        {
            MappingTablePredctionName,

            SameDiffPredictionName,
            Anti12PredictionName,
            Anti2PredictionName,

            InvertedSameDiffPredictionName,
            InvertedAnti12PredictionName,
            InvertedAnti2PredictionName
        };
    }
}
