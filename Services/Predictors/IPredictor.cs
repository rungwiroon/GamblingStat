using LanguageExt;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Services.Predictors
{
    public interface IPredictor
    {
        GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index);
    }
}
