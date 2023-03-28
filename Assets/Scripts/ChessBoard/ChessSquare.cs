using System.Collections;
using UnityEngine;

namespace Game
{
    public class ChessSquare
    {
        public ColorType ColorType { get; private set; }
        public ChessPosition ChessPosition { get; private set; }

        public ChessSquare(ChessPosition position, ColorType colorType)
        {
            ColorType = colorType;
            ChessPosition = position;
        }
    }

    public enum ColorType
    {
        Black,
        White
    }
}