namespace Game
{
    public struct ChessPosition
    {
        public char File;
        public byte Rank;

        public ChessPosition(char file, byte rank)
        {
            File = file;
            Rank = rank;
        }
    }
}