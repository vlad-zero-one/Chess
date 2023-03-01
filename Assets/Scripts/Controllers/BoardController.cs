using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Game.Settings;

namespace Game
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] private ClassicBoardSettings settings;

        [SerializeField] private ChessSquare chessSquarePrefab;

        [SerializeField] private Color darkSquareColor;
        [SerializeField] private Color lightSquareColor;

        [SerializeField] private MoveDirection md;

        private bool switcher;

        private Dictionary<ChessPosition, ChessSquare> squares;

        private Dictionary<ChessPosition, ChessPiece> chessPieces;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            SpawnSquares(settings);
        }

        private void SpawnSquares(ClassicBoardSettings settings)
        {
            squares = new();

            var squareScale = chessSquarePrefab.gameObject.transform.lossyScale;

            var files = settings.Files;
            var ranks = settings.Ranks;

            for (byte i = 0; i < files.Count; i++)
            {
                for (byte j = 0; j < ranks.Count; j++)
                {
                    var square = Instantiate(chessSquarePrefab, new Vector3(i * squareScale.x, j * squareScale.y), Quaternion.identity, transform);
                    var chessPosition = new ChessPosition(files[i], ranks[j]);
                    square.Init(chessPosition, switcher ? lightSquareColor : darkSquareColor);
                    squares.Add(chessPosition, square);

                    switcher = !switcher;
                }
                switcher = !switcher;
            }

            var boardSize = (files.Count + ranks.Count) / 2 * squareScale;
            var position = transform.position;

            transform.position = new(position.x - boardSize.x / 2 + squareScale.x / 2, position.y - boardSize.y / 2 + squareScale.x / 2);
        }

        //TODO: List.IndexOf - expensive operation, rewrite later
        public List<ChessPosition> GetMovePositions(ChessPiece chessPiece, MoveProperty moveProperty)
        {
            var movePositions = new List<ChessPosition>();
            var position = chessPiece.ChessPosition;

            if (moveProperty.MoveDirection.HasFlag(MoveDirection.Forward))
            {
                var ranks = settings.Ranks;
                var nextRankPosition = new ChessPosition();
                nextRankPosition.File = position.File;
                if (moveProperty.MoveDistance != MoveDistance.Endless && moveProperty.MoveDistance != MoveDistance.Other)
                {
                    var index = ranks.IndexOf(position.Rank);

                    if(index + (int)moveProperty.MoveDistance < ranks.Count)
                    {
                        nextRankPosition.Rank = ranks[index + (int)moveProperty.MoveDistance];
                        if (!chessPieces.ContainsKey(nextRankPosition))
                        {
                            movePositions.Add(nextRankPosition);
                        }
                        else
                        {

                        }
                    }
                }
                else if (moveProperty.MoveDistance == MoveDistance.Endless)
                {
                    for(var i = ranks.IndexOf(position.Rank) + 1; i < ranks.Count; i++)
                    {
                        nextRankPosition.Rank = ranks[i];
                        if (!chessPieces.ContainsKey(nextRankPosition))
                        {
                            movePositions.Add(nextRankPosition);
                        }
                        else
                        {

                        }
                    }
                }
            }


            return movePositions;
        }
    }
}