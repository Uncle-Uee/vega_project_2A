using Rogue.General;
using Rogue.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class GameOverUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public InGameUIController InGameCanvas;
        public HudUIController HudCanvas;

        [Header("Buttons")]
        public Button RestartButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            RestartButton.onClick.AddListener(ClickRestartButton);
            QuitButton.onClick.AddListener(ClickQuitButton);


            EventsManager.Instance.PlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            RestartButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();


            EventsManager.Instance.PlayerDeath -= PlayerDeath;
        }

        #endregion

        #region METHODS

        private void PlayerDeath()
        {
            InGameCanvas.DeactivateCanvas();
            HudCanvas.DeactivateCanvas();
            ActivateCanvas();
            Globals.PauseGameSpeed();
        }

        private void ClickRestartButton()
        {
            // ToDo - Activate the Player
            // ToDo - Reset the Player Health and Armor
            InGameCanvas.ActivateCanvas();
            HudCanvas.ActivateCanvas();
            DeactivateCanvas();
            Globals.ResumeGameSpeed();
            GameManager.Instance.PlayerEntity.Activate();
        }

        private void ClickQuitButton()
        {
            // ToDo - Destroy the Player
            // ToDo - Go Back to Title Menu
        }

        #endregion
    }
}