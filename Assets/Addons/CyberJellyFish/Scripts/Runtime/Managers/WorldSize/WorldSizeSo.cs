using CyberJellyFish.General;
using UnityEngine;

namespace CyberJellyFish.Managers
{
    [CreateAssetMenu(fileName = "WorldSizeSo", menuName = "ScriptableObjects/CyberJellyFish/WorldSize", order = 81)]
    public class WorldSizeSo : ScriptableObject
    {
        #region VARIABLES

        /// <summary>
        /// Camera Scriptable Object
        /// </summary>
        [Header("Camera Reference")]
        public CameraSo CameraSo;

        /// <summary>
        /// The Current World Size.
        /// </summary>
        [Header("Current World Size")]
        public Vector2 CurrentWorldSize;

        private Vector2 _previousWorldSize;

        #endregion

        #region METHODS

        /// <summary>
        /// Calculate the Current Size of the World
        /// </summary>
        public void CalculateWorldSize()
        {
            CurrentWorldSize.y = CameraSo.Camera.orthographicSize;
            CurrentWorldSize.x = CurrentWorldSize.y * CameraSo.Camera.aspect;


            if (Mathf.Approximately(CurrentWorldSize.x, _previousWorldSize.x) &&
                Mathf.Approximately(CurrentWorldSize.y, _previousWorldSize.y)) return;

            _previousWorldSize.y = CurrentWorldSize.y;
            _previousWorldSize.x = CurrentWorldSize.x;
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
            localPosition.y = Mathf.Clamp(localPosition.y, -CurrentWorldSize.y + yOffset, CurrentWorldSize.y - yOffset);
            localPosition.x = Mathf.Clamp(localPosition.x, -CurrentWorldSize.x + xOffset, CurrentWorldSize.x - xOffset);
        }

        #endregion
    }
}