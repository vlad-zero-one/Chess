using UnityEngine;
using System.Collections.Generic;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "ClassicBoardSettings", menuName = "Settings/ClassicBoardSettings")]
    public class ClassicBoardSettings : BoardSettings
    {
        public List<char> Files;
        public List<int> Ranks;
    }
}
