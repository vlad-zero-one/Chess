using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class ChessPiece : MonoBehaviour
    {
        protected int movesCount;

        public Owner Owner { get; protected set; }

        public ChessPosition ChessPosition { get; protected set; }

        public MoveProperty CurrentMoveProperty { get; protected set; }
        public abstract bool CanMove(ChessPosition targetPosition);
        public abstract void Move(ChessPosition targetPosition);
    }

    public enum Owner
    {
        White,
        Black
    }
}
