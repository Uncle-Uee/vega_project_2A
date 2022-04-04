using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class SettingsUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Buttons")]
        public Button BackButton;

        [Header("Audio Mixers")]
        public AudioMixerGroup BGMAudioMixer;
        public AudioMixerGroup SFXAudioMixer;

        private UIControllerBase _callingCanvas;

        #endregion

        #region PROPERTIES

        public UIControllerBase CallingCanvas
        {
            set
            {
                _callingCanvas = value;
                _callingCanvas.DeactivateCanvas();
                ActivateCanvas();
            }
        }

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            BackButton.onClick.AddListener(ClickBackButton);
        }

        #endregion

        #region METHODS

        private void ClickBackButton()
        {
            DeactivateCanvas();
            _callingCanvas.ActivateCanvas();
        }

        public void OnBGMVolume(float value)
        {
            BGMAudioMixer.audioMixer.SetFloat("BGMVolume", value);
        }

        public void OnSFXVolume(float value)
        {
            SFXAudioMixer.audioMixer.SetFloat("SFXVolume", value);
        }

        #endregion
    }
}