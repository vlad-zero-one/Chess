using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Moves
{
    public class  EnPassantMove : Move
    {
        private bool reverse;

        public void Init(bool reverse = false)
        {
            this.reverse = reverse;
        }

        public override List<ChessPosition> GetMovePositions(ChessPosition position)
        {
            var list = new List<ChessPosition>();

            list.Add(new(position.FileIndex - 1, reverse ? position.RankIndex - 1 : position.RankIndex + 1));
            list.Add(new(position.FileIndex + 1, reverse ? position.RankIndex - 1 : position.RankIndex + 1));

            return list;
        }
    }
}