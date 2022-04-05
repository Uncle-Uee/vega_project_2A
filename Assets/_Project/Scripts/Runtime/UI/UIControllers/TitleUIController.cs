using Rogue.General;
using Rogue.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class TitleUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public CharacterUIController CharacterCanvas;
        public InGameUIController InGameCanvas;
        public HudUIController HudCanvas;
        public SettingsUIController SettingsCanvas;

        [Header("Buttons")]
        public Button PlayButton;
        public Button CharacterButton;
        public Button AchievementsButton;
        public Button SettingsButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            CharacterButton.onClick.AddListener(ClickCharacterButton);
            PlayButton.onClick.AddListener(ClickPlayButton);
            AchievementsButton.onClick.AddListener(ClickAchievementsButton);
            SettingsButton.onClick.AddListener(ClickSettingsButton);
            QuitButton.onClick.AddListener(ClickQuitButton);
        }

        private void OnDisable()
        {
            CharacterButton.onClick.RemoveAllListeners();
            PlayButton.onClick.RemoveAllListeners();
            AchievementsButton.onClick.RemoveAllListeners();
            SettingsButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void ClickPlayButton()
        {
            print("Play");
            Globals.ResumeGameSpeed();
            InGameCanvas.ActivateCanvas();
            HudCanvas.ActivateCanvas();
            DeactivateCanvas();
            GameManager.Instance.GameStart();
        }

        private void ClickCharacterButton()
        {
            print("Character Selection");
            CharacterCanvas.ActivateCanvas();
            CharacterCanvas.ActivateCharacterPortrait();
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