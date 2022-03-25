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
        // Get Parent Object Transform
        _parentTransform = GetComponentInParent<Transform>();
        
        // Get Sprite Renderer of the First Child (Only Gets the First Childs Sprite Renderer even if there are many other children)
        _firstChildSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        // Get All the Sprite Renderers attached to each Child Object
        ChildrenSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    #endregion

    #region METHODS

    #endregion
}