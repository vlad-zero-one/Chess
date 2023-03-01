using System.Collections;
using UnityEngine;

namespace Game
{
    public class ChessSquare : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public ColorType ColorType { get; private set; }
        public ChessPosition ChessPosition { get; private set; }

        public void Init(ChessPosition position, ColorType colorType)
        {
            ColorType = colorType;
            ChessPosition = position;

            SetColor();
        }

        public void Init(ChessPosition position, Color color)
        {
            ChessPosition = position;

            SetColor(color);
        }

        private void SetColor()
        {
            spriteRenderer.color = ColorType == ColorType.Black ? Color.black : Color.white;
        }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }

    public enum ColorType
    {
        Black,
        White
    }
}