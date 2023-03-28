using Game.Moves;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class Pawn : ChessPiece
    {
        public Pawn(Owner owner, ChessPosition position) : base(owner, position) { }

        protected override List<Move> CreateMoves()
        {
            return new() { new PawnMove(), new PawnFirstMove(), new EnPassantMove() };
        }

        protected override void FilterMoves()
        {
            if (movesCount != 0)
            {
                RemoveMove(moves.FirstOrDefault(move => move is PawnFirstMove));
            }

            if (movesCount > 3)
            {
                RemoveMove(moves.FirstOrDefault(move => move is EnPassantMove));
            }

            foreach(var move in moves)
            {

            }
        }
    }
}
