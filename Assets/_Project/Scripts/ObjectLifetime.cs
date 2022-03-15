using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    #region VARIABLES

    public float LifeTime = 1f;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        Invoke(nameof(DestroyAfterLifetime), LifeTime);
    }

    #endregion

    #region METHODS

    private void DestroyAfterLifetime()
    {
        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    #endregion
}