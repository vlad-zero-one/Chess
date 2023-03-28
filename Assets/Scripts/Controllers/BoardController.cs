using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Game.Settings;
using Game.View;
using Game.Managers;
using DependencyInjection;

namespace Game
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] private ClassicBoardSettings boardSettings;

        [SerializeField] private ChessSquareView chessSquarePrefab;

        [SerializeField] private ChessPieceView chessPiecePrefab;

        [SerializeField] private Color darkSquareColor;
        [SerializeField] private Color lightSquareColor;

        private bool switcher;

        private Dictionary<ChessPosition, ChessSquareView> squareViews;

        private Dictionary<ChessPosition, ChessPiece> chessPieces;

        private BoardManager manager;

        public Vector2? GetBoardPosition(ChessPosition chessPosition)
        {
            if(squareViews.TryGetValue(chessPosition, out var square))
            {
                return square.transform.position;
            }

            return null;
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            manager = new BoardManager(boardSettings);
            DI.Add(manager);
            DI.Add(this);

            SpawnSquares(boardSettings);

            SpawnPieces();
        }

        private void SpawnPieces()
        {

            var pos = new ChessPosition(1, 3);
            var view = Instantiate(chessPiecePrefab);

            view.Init(new Pawn(Owner.Black, pos), this);
        }

        private void SpawnSquares(ClassicBoardSettings boardSettings)
        {
            squareViews = new();

            var squareScale = chessSquarePrefab.gameObject.transform.lossyScale;

            var files = boardSettings.Files;
            var ranks = boardSettings.Ranks;

            for (var i = 0; i < files.Count; i++)
            {
                for (var j = 0; j < ranks.Count; j++)
                {
                    var worldPosition = new Vector2(i * squareScale.x, j * squareScale.y);
                    var squareView = Instantiate(chessSquarePrefab, worldPosition, Quaternion.identity, transform);

                    var chessPosition = new ChessPosition(i, j);
                    var square = manager.GetSquare(chessPosition);
                    squareView.Init(square, switcher ? lightSquareColor : darkSquareColor, files[i], ranks[j]);

                    squareViews.Add(chessPosition, squareView);

                    switcher = !switcher;
                }
                switcher = !switcher;
            }

            var boardSize = (files.Count + ranks.Count) / 2 * squareScale;
            var position = transform.position;

            transform.position = new(position.x - boardSize.x / 2 + squareScale.x / 2, position.y - boardSize.y / 2 + squareScale.x / 2);
        }

        //TODO: List.IndexOf - expensive operation, rewrite later
        //public List<ChessPosition> GetMovePositions(ChessPiece chessPiece, MoveProperty moveProperty)
        //{
        //    var movePositions = new List<ChessPosition>();
        //    var position = chessPiece.ChessPosition;

        //    if (moveProperty.MoveDirection.HasFlag(MoveDirection.Forward))
        //    {
        //        var ranks = settings.Ranks;
        //        var nextRankPosition = new ChessPosition();
        //        nextRankPosition.File = position.File;
        //        if (moveProperty.MoveDistance != MoveDistance.Endless && moveProperty.MoveDistance != MoveDistance.Other)
        //        {
        //            var index = ranks.IndexOf(position.Rank);

        //            if(index + (int)moveProperty.MoveDistance < ranks.Count)
        //            {
        //                nextRankPosition.Rank = ranks[index + (int)moveProperty.MoveDistance];
        //                if (!chessPieces.ContainsKey(nextRankPosition))
        //                {
        //                    movePositions.Add(nextRankPosition);
        //                }
        //                else
        //                {

        //                }
        //            }
        //        }
        //        else if (moveProperty.MoveDistance == MoveDistance.Endless)
        //        {
        //            for(var i = ranks.IndexOf(position.Rank) + 1; i < ranks.Count; i++)
        //            {
        //                nextRankPosition.Rank = ranks[i];
        //                if (!chessPieces.ContainsKey(nextRankPosition))
        //                {
        //                    movePositions.Add(nextRankPosition);
        //                }
        //                else
        //                {

        //                }
        //            }
        //        }
        //    }


        //    return movePositions;
        //}
    }
}