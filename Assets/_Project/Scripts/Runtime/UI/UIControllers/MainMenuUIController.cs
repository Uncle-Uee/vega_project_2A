using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class MainMenuUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Buttons")]
        public Button PlayButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            PlayButton.onClick.AddListener(ClickPlayButton);
            QuitButton.onClick.AddListener(ClickQuitButton);
        }

        private void OnDisable()
        {
            PlayButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        public void ClickPlayButton()
        {
            DeactivateCanvas();
        }

        public void ClickQuitButton()
        {
            Application.Quit();
        }

        #endregion
    }
}