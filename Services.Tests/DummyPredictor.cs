using Services.Domain;
using Services.Predictors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    public class DummyPredictor : IPredictor
    {
        public GameStateOutput Predict(IEnumerable<GameStateOutput> gameStates, int index)
        {
            return gameStates.ElementAt(index);
        }
    }
}
