using UnityEngine;

namespace CyberJellyFish.General
{
    [RequireComponent(typeof(Camera))]
    public class GameCamera : MonoBehaviour
    {
        #region VARIABLES

        [Header("Game Camera")]
        public Camera SceneCameraReference;

        [Header("Camera Reference")]
        public CameraSo CameraSo;

        #endregion

        #region UNITY METHODS

        public void Awake()
        {
            CameraSo.SetCameraReference(SceneCameraReference);
        }

        #endregion
    }
}