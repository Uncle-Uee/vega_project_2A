using System.Collections.Generic;
using Rogue.Player;
using UnityEngine;

namespace Rogue.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Players")]
        public List<PlayerEntity> PlayerPrefabs = new List<PlayerEntity>();

        [Header("Player Properties")]
        public Transform PlayerParent;

        #endregion

        #region UNITY METHODS

        #endregion

        #region METHODS

        public void InstantiatePlayer(int playerIndex)
        {
            Instantiate(PlayerPrefabs[playerIndex], PlayerParent);
        }

        #endregion
    }
}