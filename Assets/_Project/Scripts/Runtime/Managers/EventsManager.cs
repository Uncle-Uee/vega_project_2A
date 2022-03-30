using System;
using UnityEngine;

namespace Rogue
{
    public class EventsManager : MonoBehaviour
    {
        #region VARIABLES

        public static EventsManager Instance;

        public event Action<string> UpdateGoldText;

        public event Action<float> UpdateHealth;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != this) Destroy(gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region METHODS

        public void OnUpdateGoldText(string amount)
        {
            UpdateGoldText?.Invoke(amount);
        }

        public void OnUpdateHealth(float amount)
        {
            UpdateHealth?.Invoke(amount);
        }

        #endregion
    }
}