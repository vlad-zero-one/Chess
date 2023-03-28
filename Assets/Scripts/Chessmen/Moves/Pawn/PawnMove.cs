using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Moves
{
    public class PawnMove : Move
    {
        private BoardController boardController;
        private ChessPiece chessPiece;

        private MoveProperty moveProperty = new(MoveDirection.Forward, MoveDistance.OneSquare);
        private List<ChessPosition> positions;

        private bool reverse;

        public void Init(BoardController boardController)
        {
            this.boardController = boardController;
        }

        //public void Init2(bool reverse = false)
        //{
        //    this.reverse = reverse;
        //}

        //public void Execute()
        //{
        //    if (IsAvailable())
        //    {

        //    }
        //}

        //public bool IsAvailable()
        //{
        //    positions = boardController.GetMovePositions(chessPiece, moveProperty);
        //    return positions.Count != 0;
        //}

        // ÕŒ¬¿ﬂ œ¿–¿ƒ»√Ã¿
        public override List<ChessPosition> GetMovePositions(ChessPosition position)
        {
            var list = new List<ChessPosition>();
            
            list.Add(new(position.FileIndex, reverse ? position.RankIndex - 1 : position.RankIndex + 1));

            return list;        
        }
    }
}