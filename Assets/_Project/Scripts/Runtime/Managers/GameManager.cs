using Rogue.Player;
using UnityEngine;

namespace Rogue.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Player Entity")]
        public PlayerEntity PlayerEntity;

        public static GameManager Instance;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(Instance.gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            EventsManager.Instance.RegisterPlayer += RegisterPlayer;
            EventsManager.Instance.UnregisterPlayer += UnregisterPlayer;
        }

        private void OnDisable()
        {
            EventsManager.Instance.RegisterPlayer -= RegisterPlayer;
            EventsManager.Instance.UnregisterPlayer -= UnregisterPlayer;
        }

        #endregion

        #region METHODS

        private void RegisterPlayer(PlayerEntity playerEntity)
        {
            PlayerEntity = playerEntity;
        }

        private void UnregisterPlayer()
        {
            PlayerEntity = null;
        }

        #endregion
    }
}