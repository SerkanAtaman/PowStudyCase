using System;
using POW.Cubes;
using POW.Gameplay.MatchingArea;

namespace POW.Gameplay.MatchSystem
{
    public class MatchHandler
    {
        private MatchManager _matchManager;

        public MatchHandler(MatchManager manager)
        {
            _matchManager = manager;
        }

        public bool CheckMatches(ReservedCubes reservedCubes, Action<CubeMono[]> onMatchFound, Action callback)
        {
            CubeMono[] matchedCubes = reservedCubes.GetMatchedCubes();

            if (matchedCubes == null) return false;

            reservedCubes.RemoveCubes(matchedCubes);

            onMatchFound?.Invoke(matchedCubes);
            callback?.Invoke();

            return true;
        }
    }
}