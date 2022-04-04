using System;
using CyberJellyFish.Utility;
using Rogue.Serializables;
using UnityEngine;
using UnityEngine.UI;

namespace Rogue.Attributes
{
    public class EntityHealth : MonoBehaviour
    {
        #region VARIABLES

        [Header("Health")]
        public Health Health;

        [Header("Health Status")]
        public bool HasHealth = true;
        public bool CanGetHealth = true;

        [Header("Armor UI")]
        public Image HealthImage;

        #endregion

        #region PROPERTIES

        public float MaxHealth
        {
            get => Health.MaxHealth;
        }

        public float CurrentMaxHealth
        {
            get => Health.CurrentMaxHealth;
            set => Health.CurrentMaxHealth = value;
        }

        public float CurrentHealth
        {
            get => Health.CurrentHealth;
            set => Health.CurrentHealth = value;
        }

        #endregion

        #region PROPERTIES

        public float CurrentHealthPercentage => Mathf.Clamp01(MathUtility.GetPercentageFromValue(CurrentHealth, 0, CurrentMaxHealth));

        #endregion

        #region METHODS

        public virtual void ResetHealth()
        {
            if (MaxHealth != 0 && CurrentMaxHealth == 0 && CurrentHealth == 0)
            {
                CurrentMaxHealth = MaxHealth;
                return;
            }

            CurrentHealth = CurrentMaxHealth;
            HasHealth = CurrentHealth > 0;
            UpdateHealthUI();
        }

        public virtual void IncreaseMaxHealth(float value)
        {
            if (!Mathf.Approximately(CurrentMaxHealth, MaxHealth)) return;
            CurrentMaxHealth += value;
            if (CurrentMaxHealth > MaxHealth) CurrentMaxHealth = MaxHealth;
        }

        public virtual void GetHealth(float value)
        {
            if (!CanGetHealth) return;
            if (!Mathf.Approximately(CurrentMaxHealth, MaxHealth)) return;
            CurrentHealth += value;
            if (CurrentHealth > CurrentMaxHealth) CurrentHealth = CurrentMaxHealth;
            UpdateHealthUI();
        }

        public virtual void LoseHealth(float value, Action takeDamageCallback = null, Action noHealthCallback = null)
        {
            if (!HasHealth) return;

            CurrentHealth -= value;
            if (CurrentHealth < 0) CurrentHealth = 0;
            HasHealth = CurrentHealth > 0;
            UpdateHealthUI();
            if (HasHealth)
            {
                takeDamageCallback?.Invoke();
                return;
            }

            noHealthCallback?.Invoke();
        }

        public virtual void UpdateHealthUI()
        {
            if (!HealthImage) return;
            HealthImage.fillAmount = Mathf.Clamp01(MathUtility.GetPercentageFromValue(CurrentHealth, 0, CurrentMaxHealth));
        }

        #endregion
    }
}