using Game.Moves;
using Game.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ChessPiece
    {
        protected int movesCount;

        private List<ChessPosition> movePostions;

        public Owner Owner { get; protected set; }

        public ChessPosition ChessPosition { get; protected set; }

        public MoveProperty CurrentMoveProperty { get; protected set; }

        protected List<Move> moves;

        public ChessPiece(Owner owner, ChessPosition position)
        {
            moves = CreateMoves();
            Owner = owner;
            ChessPosition = position;

            movePostions = new();
        }

        /// <summary>
        /// Removes move (used when piece has only one chance for that move, e.g. castling)
        /// </summary>
        /// <param name="move"></param>
        protected void RemoveMove(Move move) 
        {
            if (move != null) moves.Remove(move);
        }

        /// <summary>
        /// Chess piece's moves creation
        /// </summary>
        /// <returns>List of the moves created</returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual List<Move> CreateMoves()
        {
            throw new NotImplementedException();
        }

        public virtual bool CanMove(ChessPosition targetPosition)
        {
            return false;
        }

        public virtual void Move(ChessPosition targetPosition)
        {
            return;
        }

        /// <summary>
        /// Filters current moves and decides which are unacceptable right now
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual void FilterMoves()
        {
            throw new NotImplementedException();
        }

        // ÕŒ¬¿ﬂ œ¿–¿ƒ»√Ã¿
        public List<ChessPosition> GetMovePositions()
        {
            FilterMoves();

            foreach (var move in moves)
            {
                movePostions.AddRange(move.GetMovePositions(ChessPosition));
            }

            ProtectKingFilter();

            return movePostions;
        }

        private void ProtectKingFilter()
        {
            return;
        }
    }

    public enum Owner
    {
        White,
        Black
    }
}
