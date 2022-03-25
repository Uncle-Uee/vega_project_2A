using CyberJellyFish.General;
using UnityEngine;

namespace CyberJellyFish.Managers
{
    public class WorldSizeManager : ManagerBase<WorldSizeManager>
    {
        #region VARIABLES

        [Header("Camera")]
        public CameraSo CameraSo;

        [Header("World Size")]
        public WorldSizeSo WorldSizeSo;

        private Vector2 _currentWorldSize;
        private Vector2 _previousWorldSize;

        #endregion

        #region UNITY METHODS

        public override void Awake()
        {
            base.Awake();
            InitializeSingleton(this);
        }

        private void Start()
        {
            CalculateWorldSize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Calculate the Current Size of the World
        /// </summary>
        public void CalculateWorldSize()
        {
            _currentWorldSize.y = CameraSo.Camera.orthographicSize;
            _currentWorldSize.x = _currentWorldSize.y * CameraSo.Camera.aspect;


            if (Mathf.Approximately(_currentWorldSize.x, _previousWorldSize.x) &&
                Mathf.Approximately(_currentWorldSize.y, _previousWorldSize.y)) return;

            WorldSizeSo.CurrentWorldSize = _currentWorldSize;

            _previousWorldSize.y = _currentWorldSize.y;
            _previousWorldSize.x = _currentWorldSize.x;
        }

        public static void OnCalculateWorldSize()
        {
            if (!Instance) return;
            Instance.CalculateWorldSize();
        }

        /// <summary>
        /// Bound a Transform within the World.
        /// </summary>
        /// <param name="localPosition"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <returns></returns>
        public void BoundWithinScreen(ref Vector3 localPosition, float xOffset = 0f, float yOffset = 0f)
        {
            localPosition.y = Mathf.Clamp(localPosition.y, -_currentWorldSize.y + yOffset, _currentWorldSize.y - yOffset);
            localPosition.x = Mathf.Clamp(localPosition.x, -_currentWorldSize.x + xOffset, _currentWorldSize.x - xOffset);
        }

        #endregion
    }
}