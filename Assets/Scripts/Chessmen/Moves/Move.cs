using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Moves
{
    public abstract class Move
    {
        public abstract List<ChessPosition> GetMovePositions(ChessPosition position);
    }
}
