using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStat.Services.Domain
{
    public enum DrTomCircuit
    {
        Balance,
        Imbalance
    }

    public enum DrTomSign
    {
        Plus,
        Minus
    }

    public enum DrTom12
    {
        One,
        Two
    }

    public enum DrTomC
    {
        CMinus,
        CPlus
    }

    public class DrTomPrediction
    {
        public DrTomCircuit Circuit { get; private set; }

        public Option<DrTomSign> Sign { get; private set; }
        public Option<bool> SignChanged { get; private set; }

        public Option<DrTom12> OneTwo { get; private set; }
        public Option<DrTom12> OneTwoHistory { get; private set; }

        public Option<DrTomSign> CTempSign { get; private set; }
        public Option<DrTomC> C { get; private set; }
        public Option<DrTomC> CHistory { get; private set; }

        public Option<Result> Result { get; private set; }

        public DrTomPrediction(
            DrTomCircuit circuit,
            Option<DrTomSign> sign,
            Option<bool> signChanged,
            Option<DrTom12> oneTwo,
            Option<DrTom12> oneTwoHistory,
            Option<DrTomSign> cTempSign,
            Option<DrTomC> c,
            Option<DrTomC> cHistory,
            Option<Result> result)
        {
            Circuit = circuit;

            Sign = sign;
            SignChanged = signChanged;

            OneTwo = oneTwo;
            OneTwoHistory = oneTwoHistory;

            CTempSign = cTempSign;
            C = c;
            CHistory = cHistory;

            Result = result;
        }
    }
}
