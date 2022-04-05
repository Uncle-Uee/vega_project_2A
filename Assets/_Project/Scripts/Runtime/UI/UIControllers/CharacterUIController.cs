using System.Collections.Generic;
using Rogue.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class CharacterUIController : UIControllerBase
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public TitleUIController TitleCanvas;

        [Header("Buttons")]
        public Button BackButton;

        [Header("Character Selection UI")]
        public CharacterUI CurrentCharacterUI;
        [SerializeField]
        private List<CharacterUI> _charactersUI = new List<CharacterUI>();

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            BackButton.onClick.AddListener(ClickBackButton);
        }

        private void OnDisable()
        {
            BackButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region METHODS

        private void ClickBackButton()
        {
            TitleCanvas.ActivateCanvas();
            DeactivateCanvas();
        }

        public void UpdateCurrentCharacter(CharacterUI characterUI)
        {
            if (CurrentCharacterUI) CurrentCharacterUI.UnselectCharacter();
            CurrentCharacterUI = characterUI;
            CurrentCharacterUI.SelectCharacter();
            GameManager.Instance.PlayerManager.SelectedPlayerIndex = CurrentCharacterUI.CharacterIndex;
        }

        public void ActivateCharacterPortrait()
        {
            UpdateCurrentCharacter(_charactersUI[GameManager.Instance.PlayerManager.SelectedPlayerIndex]);
        }

        #endregion
    }
}