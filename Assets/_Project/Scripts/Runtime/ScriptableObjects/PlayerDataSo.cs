using UnityEngine;

namespace Rogue
{
    [CreateAssetMenu(fileName = "PlayerDataSo", menuName = "ScriptableObjects/Player Data")]
    public class PlayerDataSo : ScriptableObject
    {
        #region VARIABLES

        [Header("Gold")]
        public int Gold = 0;

        #endregion

        #region METHODS

        #endregion
    }
}