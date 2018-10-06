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
        GameState Predict(IEnumerable<GameState> gameStates, int index);
    }
}
