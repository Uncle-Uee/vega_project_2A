using System;
using UnityEngine;

namespace Rogue.Managers
{
    [DefaultExecutionOrder(-100)]
    public class EventsManager : MonoBehaviour
    {
        #region GLOBAL VARIABLES

        public static EventsManager Instance;

        #endregion

        #region PLAYER EVENTS

        public event Action PlayerDeath;

        #endregion

        #region HUD EVENTS

        public event Action<string> UpdateGoldText;

        public event Action<float> UpdateHealth;

        public event Action<float> UpdateArmor;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region PLAYER EVENT METHODS

        public void OnPlayerDeath()
        {
            PlayerDeath?.Invoke();
        }

        #endregion

        #region HUD EVENT METHODS

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