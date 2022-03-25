using UnityEngine;

namespace CyberJellyFish.General
{
    public class Mouse2D : MonoBehaviour
    {
        #region VARIABLES

        [Header("Contact Layer")]
        public LayerMask ContactMask;
        private Camera _camera;
        private Vector3 _mousePosition = Vector3.zero;

        #endregion

        #region UNITY METHODS

        public virtual void Awake()
        {
            _camera = Camera.main;
        }

        public virtual void Update()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        #endregion

        #region METHODS

        public static Vector2 GetMousePosition(Vector2 inputAxis, Camera camera, out Vector2 mousePosition)
        {
            mousePosition = camera.ScreenToWorldPoint(inputAxis);
            return mousePosition;
        }

        #endregion
    }
}