using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class ChessPiece : MonoBehaviour
    {
        public ChessPosition ChessPosition { get; private set; }

        public abstract bool CanMove(ChessPosition targetPosition);
        public abstract void Move(ChessPosition targetPosition);

    }
}
