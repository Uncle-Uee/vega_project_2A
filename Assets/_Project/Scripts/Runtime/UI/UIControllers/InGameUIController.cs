using Rogue.General;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class InGameUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Canvases")]
        public PauseMenuUIController PauseCanvas;
        public HudUIController HudUICanvas;

        [Header("Buttons")]
        public Button PauseButton;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            PauseButton.onClick.AddListener(ClickPauseButton);
        }

        private void OnDisable()
        {
            PauseButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void ClickPauseButton()
        {
            Globals.PauseGameSpeed();
            PauseCanvas.ActivateCanvas();
            HudUICanvas.DeactivateCanvas();
            DeactivateCanvas();
        }

        #endregion
    }
}