using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberJellyFish.General
{
    public class Mouse3D : MonoBehaviour
    {
        #region VARIABLES

        [Header("Contact Layer")]
        public LayerMask ContactMask;

        [Header("Distance")]
        public float RayDistance = 999f;

        private Camera _camera;
        private Vector3 _mousePosition;
        private Ray _ray;
        private RaycastHit _rayCastHit;

        #endregion

        #region UNITY METHODS

        public virtual void Awake()
        {
            _camera = Camera.main;
        }

        public virtual void Update()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _rayCastHit, RayDistance, ContactMask))
            {
                _mousePosition = _rayCastHit.point;
            }
        }

        #endregion

        #region METHODS

        public static Vector3 GetMousePosition(Vector3 inputAxis, Camera camera, Ray ray, out RaycastHit hit,
                                               float distance, LayerMask layerMask, out Vector3 mousePosition)
        {
            mousePosition = Vector3.zero;

            ray = camera.ScreenPointToRay(inputAxis);
            if (!Physics.Raycast(ray, out hit, distance, layerMask)) return mousePosition;
            mousePosition = hit.point;
            return mousePosition;
        }

        public static Vector3 GetMousePositionWithoutZ(Vector3 inputAxis, Camera camera, Ray ray, out RaycastHit hit,
                                                       float distance, LayerMask layerMask, out Vector3 mousePosition)
        {
            mousePosition = GetMousePosition(inputAxis, camera, ray, out hit, distance, layerMask, out mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        public static Vector3 RotateToMouse(Vector3 inputAxis, Transform origin, Camera camera, Ray ray,
                                            out RaycastHit hit, LayerMask layerMask, out Vector3 direction)
        {
            direction = Vector3.zero;
            ray = camera.ScreenPointToRay(inputAxis);
            if (!Physics.Raycast(ray, out hit, layerMask)) return direction;

            direction = hit.point - origin.position;
            direction.Normalize();

            return direction;
        }

        #endregion
    }
}