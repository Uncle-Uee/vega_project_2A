using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        #region VARIABLES

        [Header("Portrait")]
        [SerializeField]
        private Image PortraitImage;

        [Header("Health")]
        [SerializeField]
        private Image HealthFillImage;

        [Header("Armor")]
        [SerializeField]
        private Image ArmorFillImage;

        [Header("Gold")]
        [SerializeField]
        private TMP_Text GoldText;

        #endregion

        #region METHODS

        public void SetPortraitImage(Sprite image)
        {
            PortraitImage.sprite = image;
        }

        public void SetHealthFillAmount(float amount)
        {
            HealthFillImage.fillAmount = amount;
        }

        public void SetArmorFillAmount(float amount)
        {
            ArmorFillImage.fillAmount = amount;
        }

        public void SetGoldText(string value)
        {
            GoldText.SetText(value);
        }

        #endregion
    }
}