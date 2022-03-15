using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GetComponentsExample : MonoBehaviour
    {
        #region VARIABLES

        public SpriteRenderer SpriteRenderer;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        #endregion

        #region METHODS

        #endregion
    }