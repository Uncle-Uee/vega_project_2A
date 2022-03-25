using UnityEngine;

public class FindObjectsExample : MonoBehaviour
{
    #region VARIABLES

    public GameObject Camera;
    public MoveYeti yeti;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        yeti = FindObjectOfType<MoveYeti>();
    }

    #endregion

    #region METHODS

    #endregion
}