using GamblingStat.Services.Domain;
using System;

namespace GamblingStat.Services.Predictors
{
    public interface IPredictor
    {
        IObservable<GameStateOutput> Predict(IObservable<GameStateOutput> gameStates);
    }
}
