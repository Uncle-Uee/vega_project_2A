using Rogue.General;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class TitleUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public InGameUIController InGameCanvas;
        public HudUIController HudCanvas;
        public SettingsUIController SettingsCanvas;

        [Header("Buttons")]
        public Button PlayButton;
        public Button AchievementsButton;
        public Button SettingsButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            PlayButton.onClick.AddListener(ClickPlayButton);
            AchievementsButton.onClick.AddListener(ClickAchievementsButton);
            SettingsButton.onClick.AddListener(ClickSettingsButton);
            QuitButton.onClick.AddListener(ClickQuitButton);
        }

        private void OnDisable()
        {
            PlayButton.onClick.RemoveAllListeners();
            AchievementsButton.onClick.RemoveAllListeners();
            SettingsButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void ClickPlayButton()
        {
            Globals.ResumeGameSpeed();
            InGameCanvas.ActivateCanvas();
            HudCanvas.ActivateCanvas();
            DeactivateCanvas();
        }

        private void ClickAchievementsButton()
        {
            print("Achievements");
        }

        private void ClickSettingsButton()
        {
            print("Settings");
            SettingsCanvas.CallingCanvas = this;
        }

        private void ClickQuitButton()
        {
            Application.Quit();
        }

        #endregion
    }
}