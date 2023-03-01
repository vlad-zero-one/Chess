namespace Game.Moves
{
    public interface IMove
    {
        /// <summary>
        /// Init Move with board controller
        /// </summary>
        void Init(BoardController boardController);

        /// <summary>
        /// Returns true if this move is available false if not.
        /// </summary>
        /// <returns>Returns true if this move is available false if not.</returns>
        bool IsAvailable();

        /// <summary>
        /// Execute move
        /// </summary>
        void Execute();
    }
}
