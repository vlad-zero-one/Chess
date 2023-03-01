using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class Pawn : ChessPiece
    {
        [SerializeField] private MovePropertySerializable firstMove;
        [SerializeField] private MovePropertySerializable enPassantMove;
        [SerializeField] private MovePropertySerializable defaultMove;

        public IObservable<Null> OnMove => onMove;

        private Subject<Null> onMove = new();

        public override bool CanMove(ChessPosition targetPosition)
        {
            throw new System.NotImplementedException();
        }

        public override void Move(ChessPosition targetPosition)
        {
            if (!CanMove(targetPosition)) return;

            ChessPosition = targetPosition;
            movesCount++;
            onMove.OnNext(null);
        }

        public void Init(Owner owner)
        {
            CurrentMoveProperty = firstMove.Get;
            Owner = owner;
        }
    }
}
