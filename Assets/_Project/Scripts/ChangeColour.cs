using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColour : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeToRandomColour();
    }

    #endregion

    #region METHODS


    private void ChangeToRandomColour()
    {
        _spriteRenderer.color = Random.ColorHSV();
    }
    
    #endregion
}