namespace Game
{
    public struct ChessPosition
    {
        public int FileIndex;
        public int RankIndex;

        public ChessPosition(int fileIndex, int rankIndex)
        {
            FileIndex = fileIndex;
            RankIndex = rankIndex;
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            //DependencyInjection.DI.Get<Managers.BoardManager>();

            return $"{FileIndex}{RankIndex}";
        }
    }
#endif
}