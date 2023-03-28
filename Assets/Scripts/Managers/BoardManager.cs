using Game.Settings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Managers
{
    public class BoardManager
    {
        private readonly ClassicBoardSettings boardSettings;

        private Dictionary<ChessPosition, ChessSquare> squares;

        private Dictionary<ChessPosition, ChessPiece> pieces;

        private bool switcher;

        public BoardManager(ClassicBoardSettings boardSettings)
        {
            this.boardSettings = boardSettings;

            CreateSquares();
        }

        public ChessSquare GetSquare(ChessPosition chessPosition)
        {
            return squares[chessPosition];
        }

        public ChessPiece GetPiece(ChessPosition chessPosition)
        {
            if(pieces.TryGetValue(chessPosition, out var piece))
            {
                return piece;
            }

            return null;
        }

        private void CreateSquares()
        {
            squares = new();

            var files = boardSettings.Files;
            var ranks = boardSettings.Ranks;

            for (var i = 0; i < files.Count; i++)
            {
                for (var j = 0; j < ranks.Count; j++)
                {
                    var chessPosition = new ChessPosition(i, j);
                    var square = new ChessSquare(chessPosition, switcher ? ColorType.White : ColorType.Black);
                    squares.Add(chessPosition, square);

                    switcher = !switcher;
                }
                switcher = !switcher;
            }
        }
    }
}