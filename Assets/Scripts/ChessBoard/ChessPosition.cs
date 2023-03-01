namespace Game
{
    public struct ChessPosition
    {
        public char File;
        public int Rank;

        public ChessPosition(char file, int rank)
        {
            File = file;
            Rank = rank;
        }
    }
}