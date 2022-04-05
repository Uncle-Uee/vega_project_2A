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
        public TitleUIController TitleCanvas;
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
            GameManager.Instance.GameOver();
        }

        private void ClickRestartButton()
        {
            print("Restart");
            InGameCanvas.ActivateCanvas();
            HudCanvas.ActivateCanvas();
            DeactivateCanvas();
            GameManager.Instance.GameRestart();
        }

        private void ClickQuitButton()
        {
            print("Quit");
            TitleCanvas.ActivateCanvas();
            InGameCanvas.DeactivateCanvas();
            HudCanvas.DeactivateCanvas();
            DeactivateCanvas();
            GameManager.Instance.GameQuit();
        }

        #endregion
    }
}