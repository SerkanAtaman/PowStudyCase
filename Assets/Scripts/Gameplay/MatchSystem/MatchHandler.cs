using System;
using UnityEngine;
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

        public void CheckMatches(ReservedCubes reservedCubes, Action onMatchFound)
        {
            CubeMono[] matchedCubes = reservedCubes.GetMatchedCubes();

            if (matchedCubes == null) return;

            reservedCubes.RemoveCubes(matchedCubes);

            onMatchFound?.Invoke();
        }
    }
}