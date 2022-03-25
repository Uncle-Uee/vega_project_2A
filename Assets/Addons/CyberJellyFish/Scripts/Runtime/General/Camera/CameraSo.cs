using UnityEngine;

namespace CyberJellyFish.General
{
    public class CameraSo : ScriptableObject
    {
        #region VARIABLES

        [Header("Scene Camera")]
        public Camera Camera;

        #endregion

        #region METHODS

        public void SetCameraReference(Camera camera)
        {
            Camera = camera;
        }

        #endregion
    }
}