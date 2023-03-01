using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Moves
{
    public class PawnMove : IMove
    {
        private BoardController boardController;
        private ChessPiece chessPiece;

        private MoveProperty moveProperty = new(MoveDirection.Forward, MoveDistance.OneSquare);
        private List<ChessPosition> positions;

        public void Init(BoardController boardController)
        {
            this.boardController = boardController;
        }

        public void Execute()
        {
            if (IsAvailable())
            {

            }
        }

        public bool IsAvailable()
        {
            positions = boardController.GetMovePositions(chessPiece, moveProperty);
            return positions.Count != 0;
        }
    }
}