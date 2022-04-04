using Rogue.General;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class PauseMenuUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public TitleUIController TitleCanvas;
        public InGameUIController InGameCanvas;
        public HudUIController HudCanvas;
        public SettingsUIController SettingsCanvas;

        [Header("Buttons")]
        public Button ResumeButton;
        public Button SettingsButton;
        public Button SaveButton;
        public Button LoadButton;
        public Button QuitButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            ResumeButton.onClick.AddListener(ClickResumeButton);
            SettingsButton.onClick.AddListener(ClickSettingsButton);
            SaveButton.onClick.AddListener(ClickSaveButton);
            LoadButton.onClick.AddListener(ClickLoadButton);
            QuitButton.onClick.AddListener(ClickQuitButton);
        }

        private void OnDisable()
        {
            ResumeButton.onClick.RemoveAllListeners();
            SettingsButton.onClick.RemoveAllListeners();
            SaveButton.onClick.RemoveAllListeners();
            LoadButton.onClick.RemoveAllListeners();
            QuitButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void ClickResumeButton()
        {
            Globals.ResumeGameSpeed();
            InGameCanvas.ActivateCanvas();
            HudCanvas.ActivateCanvas();
            DeactivateCanvas();
        }

        private void ClickSettingsButton()
        {
            print("Settings");
            SettingsCanvas.CallingCanvas = this;
            
        }

        private void ClickSaveButton()
        {
            print("Save");
        }

        private void ClickLoadButton()
        {
            print("Load");
        }

        private void ClickQuitButton()
        {
            print("Quit Level");
            TitleCanvas.ActivateCanvas();
            DeactivateCanvas();
        }

        #endregion
    }
}