using UnityEngine;
using UnityEngine.UI;

namespace Uee.UI.Bars
{
    public class ProgressBar : MonoBehaviour
    {
        #region VARIABLES

        [Header("Progress Bar Properties")]
        public float Minimum;
        public float Maximum;

        [Header("Current Progress")]
        public float Current;

        [Header("Progress Bar UI Properties")]
        public Image Mask;
        public Image Fill;
        public Color Color;

        #endregion

        #region UNITY METHODS

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Current < 0) Current = 0;
            GetCurrentFill();
        }
#endif

        #endregion

        #region METHODS

        public void GetCurrentFill()
        {
            float currentOffset = Current - Minimum;
            float maximumOffset = Maximum - Minimum;
            float fillAmount = currentOffset / maximumOffset;
            Mask.fillAmount = fillAmount;
            Fill.color = Color;

            if (Current < Maximum) return;
            fillAmount = 1f;
            Mask.fillAmount = fillAmount;
            Current = Maximum;
        }

        #endregion
    }
}