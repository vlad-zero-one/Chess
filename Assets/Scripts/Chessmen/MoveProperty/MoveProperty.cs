using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveProperty
    {
        public MoveDirection MoveDirection { get; }
        public MoveDistance MoveDistance { get; }

        public MoveProperty(MoveDirection moveDirection, MoveDistance moveDistance)
        {
            MoveDirection = moveDirection;
            MoveDistance = moveDistance;
        }
    }

    [Serializable]
    public class MovePropertySerializable
    {
        [SerializeField] private MoveDirection moveDirection;
        [SerializeField] private MoveDistance moveDistance;

        private MoveProperty instance;

        public MoveProperty Get => instance ??= new(moveDirection, moveDistance);
    }
}
