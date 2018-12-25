using System;
using System.Collections.Generic;
using System.Text;

namespace GamblingStat.Services.Domain
{
    public class GameStateOutputGroup
    {
        public IEnumerable<GameStateOutputDetail> GameStatesWithScorePrediction { get; private set; }
        public IEnumerable<GameStateOutput> GameStatesWithResultPrediction { get; private set; }

        public GameStateOutputGroup(
            IEnumerable<GameStateOutputDetail> gameStatesWithScorePrediction,
            IEnumerable<GameStateOutput> gameStatesWithResultPrediction)
        {
            GameStatesWithScorePrediction = gameStatesWithScorePrediction;
            GameStatesWithResultPrediction = gameStatesWithResultPrediction;
        }
    }

    public class GameStateOutputDetail
    {
        public IEnumerable<GameStateOutput> GameStates { get; private set; }
        public Stat Stat { get; private set; }

        public GameStateOutputDetail(
            IEnumerable<GameStateOutput> gameStates,
            Stat stat)
        {
            GameStates = gameStates;
            Stat = stat;
        }
    }
}
