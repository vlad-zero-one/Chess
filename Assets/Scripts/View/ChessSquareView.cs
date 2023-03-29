using System.Collections;
using UnityEngine;

namespace Game.View
{
    public class ChessSquareView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private ChessSquare chessSquare;

        public void Init(ChessSquare chessSquare, Color color, char file, int rank)
        {
            File = file;
            Rank = rank;
            this.chessSquare = chessSquare;

            SetColor(color);
        }

        public char File { get; private set; }
        public int Rank { get; private set; }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}