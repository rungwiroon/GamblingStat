using LanguageExt;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace GamblingStat.Services.Domain
{
    public class GameStateOutputGroup
    {
        public IEnumerable<GameStateOutputDetail> GameStateWithScorePredictions { get; private set; }
        public GameStateOutput GameStateWithResultPrediction { get; private set; }

        public GameStateOutputGroup(
            IEnumerable<GameStateOutputDetail> gameStateWithScorePredictions,
            GameStateOutput gameStateWithResultPrediction)
        {
            GameStateWithScorePredictions = gameStateWithScorePredictions;
            GameStateWithResultPrediction = gameStateWithResultPrediction;
        }
    }

    public class GameStateOutputDetail
    {
        public GameStateOutput GameState { get; private set; }
        public Option<Stat> Stat { get; private set; }

        public GameStateOutputDetail(
            GameStateOutput gameState,
            Option<Stat> stat)
        {
            GameState = gameState;
            Stat = stat;
        }
    }
}
