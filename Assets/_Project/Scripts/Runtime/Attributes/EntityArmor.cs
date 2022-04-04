using System;
using CyberJellyFish.Utility;
using Rogue.Serializables;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.Attributes
{
    public class EntityArmor : MonoBehaviour
    {
        #region VARIABLES

        [Header("Armor")]
        public Armor Armor;

        [Header("Armor Status")]
        public bool HasArmor = false;
        public bool CanGetArmor = true;

        [Header("Armor UI")]
        public Image ArmorImage;

        #endregion

        #region PROPERTIES

        public float MaxArmor
        {
            get => Armor.MaxArmor;
            set => Armor.MaxArmor = value;
        }

        public float CurrentMaxArmor
        {
            get => Armor.CurrentMaxArmor;
            set => Armor.CurrentMaxArmor = value;
        }

        public float CurrentArmor
        {
            get => Armor.CurrentArmor;
            set => Armor.CurrentArmor = value;
        }

        public float CurrentArmorPercentage => Mathf.Clamp01(MathUtility.GetPercentageFromValue(CurrentArmor, 0, CurrentMaxArmor));

        #endregion

        #region METHODS

        public virtual void ResetArmor()
        {
            if (MaxArmor != 0 && CurrentMaxArmor == 0 && CurrentArmor == 0)
            {
                CurrentMaxArmor = MaxArmor;
                return;
            }

            CurrentArmor = CurrentMaxArmor;
            HasArmor = CurrentArmor > 0;
            UpdateArmorUI();
        }

        public virtual void IncreaseMaxArmor(float value)
        {
            if (!Mathf.Approximately(CurrentMaxArmor, MaxArmor)) return;
            CurrentMaxArmor += value;
            if (CurrentMaxArmor > MaxArmor) CurrentMaxArmor = MaxArmor;
        }

        public virtual void GetArmor(float value)
        {
            if (!CanGetArmor) return;
            if (!Mathf.Approximately(CurrentMaxArmor, MaxArmor)) return;
            CurrentArmor += value;
            if (CurrentArmor > CurrentMaxArmor) CurrentArmor = CurrentMaxArmor;
            UpdateArmorUI();
        }

        public virtual void LoseArmor(float value, Action takeDamageCallback = null, Action noArmorCallback = null)
        {
            if (!HasArmor) return;

            CurrentArmor -= value;
            if (CurrentArmor < 0) CurrentArmor = 0;
            HasArmor = CurrentArmor > 0;
            UpdateArmorUI();
            if (HasArmor)
            {
                takeDamageCallback?.Invoke();
                return;
            }

            noArmorCallback?.Invoke();
        }

        public virtual void UpdateArmorUI()
        {
            if (ArmorImage) ArmorImage.fillAmount = Mathf.Clamp01(MathUtility.GetPercentageFromValue(CurrentArmor, 0, CurrentMaxArmor));
        }

        #endregion
    }
}