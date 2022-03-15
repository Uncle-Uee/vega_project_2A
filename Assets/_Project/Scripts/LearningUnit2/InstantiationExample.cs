using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationExample : MonoBehaviour
{
    #region VARIABLES

    public GameObject YetiPrefab;

    public List<GameObject> YetiPrefabs = new List<GameObject>();

    public Transform YetiParent;

    public Vector2 StartPosition = new Vector2(5, 5);

    public GameObject MyYetiClone;

    #endregion

    #region UNITY METHODS

    void Start()
    {
        // Called only once
        // Called when scene is in Play Mode
        MyYetiClone = Instantiate(YetiPrefab, StartPosition, Quaternion.identity, YetiParent);
        
        Debug.Log($"Yeti Prefabs Count - {YetiPrefabs.Count}");

        for (int i = 0; i < YetiPrefabs.Count; i += 1)
        {
            Instantiate(YetiPrefabs[i], new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity, YetiParent);
        }
    }

    void Update()
    {
        bool spaceButtonPressed = Input.GetKeyDown(KeyCode.Space);
        if (spaceButtonPressed)
        {
            Instantiate(YetiPrefabs[Random.Range(0, YetiPrefabs.Count + 1)], new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.identity, YetiParent);
        }
    }

    #endregion

    #region METHODS

    #endregion
}