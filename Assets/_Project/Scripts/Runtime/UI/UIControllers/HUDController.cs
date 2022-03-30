using System;
using UnityEngine;

namespace Rogue.UI
{
    public class HUDController : UIControllerBase
    {
        #region VARIABLES

        [Header("Required ScriptableObjects")]
        public PlayerData PlayerData;

        [Header("Player Info Panel")]
        public PlayerInfoPanel PlayerInfoPanel;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            EventsManager.Instance.UpdateGoldText += UpdateGold;
            EventsManager.Instance.UpdateHealth += UpdateHealth;
        }

        public void Start()
        {
            UpdateGold($"{PlayerData.Gold:0000000000}");
        }

        private void OnDisable()
        {
            EventsManager.Instance.UpdateGoldText -= UpdateGold;
            EventsManager.Instance.UpdateHealth -= UpdateHealth;
        }

        #endregion

        #region METHODS

        private void UpdatePortrait(Sprite image)
        {
            PlayerInfoPanel.SetPortraitImage(image);
        }

        private void UpdateHealth(float amount)
        {
            PlayerInfoPanel.SetHealthFillAmount(amount);
        }

        private void UpdateArmor(float amount)
        {
            PlayerInfoPanel.SetArmorFillAmount(amount);
        }

        private void UpdateGold(string amount)
        {
            PlayerInfoPanel.SetGoldText(amount);
        }

        #endregion
    }
}