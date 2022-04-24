using System;
using System.Collections.Generic;

namespace Rogue
{
    [Serializable]
    public class GameData
    {
        #region VARIABLES

        public List<PlayerInfo> Players = new List<PlayerInfo>();

        #endregion
    }

    [Serializable]
    public class PlayerInfo
    {
        #region VARIABLES

        public string PlayerName;
        public int Score;

        #endregion
    }
}