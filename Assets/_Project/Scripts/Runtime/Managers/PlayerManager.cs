using System.Collections.Generic;
using Rogue.Player;
using UnityEngine;

namespace Rogue.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Player Properties")]
        public PlayerEntity PlayerEntity;
        public Transform PlayerParent;

        [Header("Players")]
        public int SelectedPlayerIndex = 0;
        public List<PlayerEntity> PlayerPrefabs = new List<PlayerEntity>();

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            EventsManager.Instance.UnregisterPlayer += UnregisterPlayer;
        }

        private void OnDisable()
        {
            EventsManager.Instance.UnregisterPlayer -= UnregisterPlayer;
        }

        #endregion

        #region METHODS

        public void InstantiatePlayer()
        {
            if (PlayerEntity) return;
            PlayerEntity = Instantiate(PlayerPrefabs[SelectedPlayerIndex], PlayerParent);
        }

        public void DestroyPlayer()
        {
            if (!PlayerEntity) return;
            PlayerEntity.DestroyInstance();
        }

        private void UnregisterPlayer()
        {
            PlayerEntity = null;
        }

        #endregion
    }
}