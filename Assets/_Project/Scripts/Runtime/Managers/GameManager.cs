using Rogue.General;
using Rogue.Player;
using UnityEngine;

namespace Rogue.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region SINGLETON INSTANCE

        public static GameManager Instance;

        #endregion

        #region VARIABLES

        [Header("Managers")]
        public PlayerManager PlayerManager;

        #endregion

        #region PROPERTIES

        public PlayerEntity PlayerEntity
        {
            get => PlayerManager.PlayerEntity;
        }

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(Instance.gameObject);

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region GAME EVENT METHODS

        public void GameStart()
        {
            print("Game Start");
            PlayerManager.InstantiatePlayer();
            PlayerEntity.Activate();
        }

        public void GameOver()
        {
            print("Game Over");
            Globals.PauseGameSpeed();
        }

        public void GameRestart()
        {
            print("Game Restart");
            Globals.ResumeGameSpeed();
            PlayerEntity.Activate();
        }

        public void GameQuit()
        {
            print("Game Quit");
            PlayerManager.DestroyPlayer();
        }

        #endregion
    }
}