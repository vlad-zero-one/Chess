using System.Collections.Generic;

namespace Game.Moves
{
    public class PawnMove : Move
    {
        private bool reverse;

        public void Init(bool reverse)
        {
            this.reverse = reverse;
        }

        public override List<ChessPosition> GetMovePositions(ChessPosition position)
        {
            var list = new List<ChessPosition>
            {
                new(position.FileIndex, reverse ? position.RankIndex - 1 : position.RankIndex + 1)
            };

            return list;        
        }
    }
}