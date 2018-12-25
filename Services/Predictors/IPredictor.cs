using GamblingStat.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStat.Services.Predictors
{
    public interface IPredictor
    {
        GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index);
    }
}
