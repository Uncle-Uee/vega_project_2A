using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class CharacterUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("Other Canvases")]
        public CharacterUIController CharacterCanvas;

        [Header("Character Portrait Properties")]
        public Sprite PortraitSprite;
        public string CharacterName = string.Empty;
        public int CharacterIndex = 0;

        [Header("Character UI")]
        public Image PortraitImage;
        public TMP_Text CharacterNameText;
        public Button PortraitButton;

        [Header("Portrait Selection Colours")]
        [SerializeField]
        private Color _selectedColor = Color.white;
        [SerializeField]
        private Color _unselectedColor = Color.white;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            PortraitButton.onClick.AddListener(ClickCharacterButton);
        }

        private void Start()
        {
            UpdateCharacterPortrait();
        }

        private void OnDisable()
        {
        }

        #endregion

        #region METHODS

        public void SelectCharacter()
        {
            PortraitImage.color = _selectedColor;
        }

        public void UnselectCharacter()
        {
            PortraitImage.color = _unselectedColor;
        }

        public void ClickCharacterButton()
        {
            CharacterCanvas.UpdateCurrentCharacter(this);
        }

        private void UpdateCharacterPortrait()
        {
            gameObject.name = CharacterName;
            PortraitImage.sprite = PortraitSprite;
            CharacterNameText.SetText(CharacterName);
        }

        #endregion
    }
}