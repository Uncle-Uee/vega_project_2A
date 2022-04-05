using UnityEngine;

namespace LU3
{
    public class GameManager : MonoBehaviour
    {
        #region VARIABLES

        public static GameManager Instance;

        public int Score;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            // Ensure we only Have 1 Singleton Instance of GameManager
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // Refer Instance to itself
            Instance = this;

            // Do not destroy when we load different scenes
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region METHODS

        public void UpdateScore(int score)
        {
            Score += score;
            InGameUIController.Instance.UpdateScoreText($"{Score}");
        }

        #endregion
    }
}