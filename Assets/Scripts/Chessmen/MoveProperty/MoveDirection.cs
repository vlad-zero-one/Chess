using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    [Flags]
    public enum MoveDirection
    {
        None = 0,

        Forward = 1,
        Backward = 2,
        Left = 4,
        Right = 8,

        DiagonallyForwardLeft = 16,
        DiagonallyForwardRight = 32,
        DiagonallyBackwardLeft = 64,
        DiagonallyBackwardRight = 128,

        LShaped = 256,
    }
}

