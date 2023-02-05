using System.Collections;
using UnityEngine;
using System;

namespace Game
{
    public class BoardController : MonoBehaviour
    {
        private const string Letters = "ABCDEFGH";

        [SerializeField] private ChessSquare chessSquarePrefab;

        private bool switcher;

        private void Start()
        {
            SpawnSquares();
        }

        private void SpawnSquares(byte size = 8)
        {
            if (Letters.Length < size)
            {
                throw new Exception($"There's not enough letters to create board squares in {name}");
            }

            var squareScale = chessSquarePrefab.gameObject.transform.lossyScale;

            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++)
                {
                    var fileChar = Letters[j];

                    var square = Instantiate(chessSquarePrefab, new Vector3(i * squareScale.x, j * squareScale.y), Quaternion.identity, transform);
                    square.Init(new(fileChar, j), switcher ? ColorType.White : ColorType.Black);
                    switcher = !switcher;
                }
                switcher = !switcher;
            }

            var boardSize = size * squareScale;
            var position = transform.position;

            transform.position = new(position.x - boardSize.x / 2 + squareScale.x / 2, position.y - boardSize.y / 2 + squareScale.x / 2);
        }
    }
}