using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Domain
{
    public enum DrTom2State
    {
        One,
        Two,
        CMinus,
        CPlus
    }

    public enum DrTom3State
    {
        One,

        SignChanged,
        Two,

        CMinus,
        CPlus
    }

    public enum DrTom3Trigger
    {
        SameSign,
        DifferentSign
    }

    public class DrTom2Prediction
    {
        public Option<int> SignChanged { get; private set; }

        public Option<DrTomC> CHistory { get; private set; }

        public Option<DrTom2State> Status { get; private set; }

        public Option<Result> Result { get; private set; }

        public DrTom2Prediction(
            Option<int> signChanged,
            Option<DrTomC> lastC,
            Option<DrTom2State> status,
            Option<Result> result)
        {
            SignChanged = signChanged;
            CHistory = lastC;
            Status = status;
            Result = result;
        }
    }
}
