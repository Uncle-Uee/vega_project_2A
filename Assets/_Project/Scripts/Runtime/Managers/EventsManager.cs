using System;
using Rogue.Player;
using UnityEngine;

namespace Rogue.Managers
{
    [DefaultExecutionOrder(-100)]
    public class EventsManager : MonoBehaviour
    {
        #region GLOBAL VARIABLES

        public static EventsManager Instance;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(Instance.gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region PLAYER EVENT METHODS

        public event Action PlayerDeath;

        public event Action<PlayerEntity> RegisterPlayer;
        public event Action UnregisterPlayer;

        public void OnPlayerDeath()
        {
            PlayerDeath?.Invoke();
        }

        public void OnRegisterPlayer(PlayerEntity playerEntity)
        {
            RegisterPlayer?.Invoke(playerEntity);
        }

        public void OnUnregisterPlayer()
        {
            UnregisterPlayer?.Invoke();
        }

        #endregion

        #region HUD EVENT METHODS

        public event Action<string> UpdateGoldText;
        public event Action<float> UpdateHealth;
        public event Action<float> UpdateArmor;

        public void OnUpdateGoldText(string amount)
        {
            UpdateGoldText?.Invoke(amount);
        }

        public void OnUpdateHealth(float amount)
        {
            UpdateHealth?.Invoke(amount);
        }

        public void OnUpdateArmor(float amount)
        {
            UpdateArmor?.Invoke(amount);
        }

        #endregion
    }
}