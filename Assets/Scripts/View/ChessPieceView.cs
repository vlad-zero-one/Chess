using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.View
{
    public class ChessPieceView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private ChessPiece chessPiece;

        private Subject<Null> onClick = new();

        public IObservable<Null> OnClick => onClick.AsObservable();

        public void Init(ChessPiece chessPiece, BoardController boardController)
        {
            this.chessPiece = chessPiece;

            var pos = boardController.GetBoardPosition(chessPiece.ChessPosition);
            if (pos != null)
            {
                transform.position = pos.Value;
            }
        }
    
        private void OnMouseDown()
        {
            //onClick.OnNext(null);

            foreach(var pos in chessPiece.GetMovePositions())
            {
                Debug.LogError(pos);
            }
        }
    }
}
