using System.Collections.Generic;

namespace Game.Moves
{
    public interface IMove
    {
        /// <summary>
        /// Init Move with board controller
        /// </summary>
        public void Init(BoardController boardController);

        /// <summary>
        /// Returns true if this move is available false if not.
        /// </summary>
        /// <returns>Returns true if this move is available false if not.</returns>
        public bool IsAvailable();

        /// <summary>
        /// Execute move
        /// </summary>
        public void Execute();



        public List<ChessPosition> GetMovePositions(ChessPosition position);

    }
}
