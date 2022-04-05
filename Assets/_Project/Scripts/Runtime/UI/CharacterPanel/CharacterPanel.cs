using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class CharacterPanel : MonoBehaviour
    {
        #region VARIABLES

        [Header("")]
        public Sprite PortraitSprite;
        public string CharacterName = string.Empty;

        [Header("Character UI")]
        public Image PortraitImage;
        public TMP_Text CharacterNameText;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            UpdateCharacterPortrait();
        }

        #endregion

        #region METHODS

        private void UpdateCharacterPortrait()
        {
            gameObject.name = CharacterName;
            PortraitImage.sprite = PortraitSprite;
            CharacterNameText.SetText(CharacterName);
        }

        #endregion
    }
}