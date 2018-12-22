﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStatWeb.Shared
{
    public class PredictionModel
    {
        public string PredictionScore { get; set; }
        public int WinRate { get; set; }
        //public bool Selected { get; set; }
        //public int MappingValue { get; set; }
        public string AlgorithmType { get; set; }
        public int WrongCount { get; set; }
    }
}
