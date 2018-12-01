using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Domain
{
    public enum DrTom2Status
    {
        One,
        Two,
        CMinus,
        CPlus
    }

    public class DrTom2Prediction
    {
        public Option<int> SignChanged { get; private set; }

        //public Option<DrTom12> OneTwo { get; private set; }
        //public Option<DrTom12> OneTwoHistory { get; private set; }

        //public Option<DrTomC> C { get; private set; }
        public Option<DrTomC> CHistory { get; private set; }

        public Option<DrTom2Status> Status { get; private set; }

        public Option<Result> Result { get; private set; }

        public DrTom2Prediction(
            Option<int> signChanged,
            //Option<DrTom12> lastOneTwo,
            Option<DrTomC> lastC,
            Option<DrTom2Status> status,
            Option<Result> result)
        {
            SignChanged = signChanged;
            //OneTwoHistory = lastOneTwo;
            CHistory = lastC;
            Status = status;
            Result = result;
        }
    }
}
