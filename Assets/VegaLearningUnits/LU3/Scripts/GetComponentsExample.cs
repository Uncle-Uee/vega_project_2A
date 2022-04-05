using UnityEngine;

public class GetComponentsExample : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private Transform _parentTransform;
    [SerializeField]
    private SpriteRenderer _firstChildSpriteRenderer;
    public SpriteRenderer[] ChildrenSpriteRenderers;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        // Get Component on Object (Parent)
        Transform myTransform = GetComponent<Transform>();

        // Get a Component on the Parent From a Child
        _parentTransform = GetComponentInParent<Transform>();

        // Get Sprite Renderer of the First Child (Only Gets the First Child's Sprite Renderer even if there are many other children)
        _firstChildSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // Get All the Sprite Renderers attached to each Child Object
        ChildrenSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    #endregion
}