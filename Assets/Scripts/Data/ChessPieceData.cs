using Game.Moves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu]
    public class ChessPieceData : ScriptableObject
    {
        [SerializeField] private List<Move> moves;

        public List<Move> Moves;// => moves;
    }
}