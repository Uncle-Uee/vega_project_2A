/*
 * Created By: Ubaidullah Effendi-Emjedi
 * LinkedIn : https://www.linkedin.com/in/ubaidullah-effendi-emjedi-202494183/
 */

using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CyberJellyFish.General
{
    public class FpsMonitorUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("Status")]
        public bool MonitorFPS;

        [Header("Text")]
        public TMP_Text FpsText;

        [Header("Properties")]
        public Color FontColour = Color.white;
        [Range(16, 64)]
        public int FontSize = 48;

        private float _fpsCounter;

        private static event Action OnShowFPS;
        private static event Action OnHideFPS;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            ShowFps();
        }

        private void OnEnable()
        {
            ShowFps();

            OnShowFPS += ShowFps;
            OnHideFPS += HideFps;
        }

        private void OnDisable()
        {
            HideFps();

            OnShowFPS -= ShowFps;
            OnHideFPS -= HideFps;
        }

        private void OnGUI()
        {
            if (!MonitorFPS) return;
        }

        #endregion

        #region METHODS

        private void ShowFps()
        {
            MonitorFPS = true;
            StopAllCoroutines();
            StartCoroutine(CalculateFpsRoutine());
        }

        private void HideFps()
        {
            MonitorFPS = false;
            StopAllCoroutines();
        }

        private IEnumerator CalculateFpsRoutine()
        {
            FpsText.color = FontColour;
            FpsText.fontSize = FontSize;

            while (MonitorFPS)
            {
                if (Time.timeScale > 0)
                {
                    _fpsCounter = 1f / Time.deltaTime;
                    FpsText.SetText($"{_fpsCounter:0000}");
                }

                yield return null;
            }
        }

        public static void CallShowFps()
        {
            OnShowFPS?.Invoke();
        }

        public static void CallHideFps()
        {
            OnHideFPS?.Invoke();
        }

        #endregion
    }
}