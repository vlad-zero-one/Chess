using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Moves
{
    public class PawnFirstMove : Move
    {
        private bool reverse;

        public void Init(bool reverse = false)
        {
            this.reverse = reverse;
        }

        public override List<ChessPosition> GetMovePositions(ChessPosition position)
        {
            var list = new List<ChessPosition>();
            
            list.Add(new(position.FileIndex, reverse ? position.RankIndex - 2 : position.RankIndex + 2));

            return list;        
        }
    }
}