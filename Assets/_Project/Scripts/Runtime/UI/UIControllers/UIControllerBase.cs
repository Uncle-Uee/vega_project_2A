using System.Collections;
using UnityEngine;

namespace Rogue.UI
{
    public class UIControllerBase : MonoBehaviour
    {
        #region VARIABLES

        [Header("Current Canvas")]
        public Canvas CurrentCanvas;

        [Header("Canvas Delay Properties")]
        public float ActivateDelay = 1f;

        #endregion

        #region UNITY METHODS

        public virtual void Awake()
        {
            if (!CurrentCanvas) CurrentCanvas = GetComponent<Canvas>();
        }

        #endregion

        #region CANVAS STATE METHODS

        public void ActivateCanvasDelay()
        {
            StartCoroutine(ActivateCanvasDelayRoutine());
        }

        private IEnumerator ActivateCanvasDelayRoutine()
        {
            WaitForSeconds delay = new WaitForSeconds(ActivateDelay);
            yield return delay;
            CurrentCanvas.enabled = true;
        }

        public void DeactivateCanvas()
        {
            CurrentCanvas.enabled = false;
        }

        #endregion

        #region GAMEOBJECT STATE METHODS

        /// <summary>
        /// Activate Object
        /// </summary>
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivate Object
        /// </summary>
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Destroy Object
        /// </summary>
        public void DestroyInstance()
        {
            Destroy(this.gameObject);
        }

        #endregion

        #region EVENT METHODS

        /// <summary>
        /// Do anything required to be called during Awake here.
        /// Example:
        /// Initialization of Objects, Fields and Properties
        /// Subscribe to Events
        /// </summary>
        public void DoOnAwake()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnEnable here.
        /// Example:
        /// Reset Properties, Objects and Fields
        /// Subscribe to Events
        /// </summary>
        public void DoOnEnable()
        {
        }

        /// <summary>
        /// Do anything required to be called during Start here.
        /// Example:
        /// Initialize Objects
        /// Subscribe to Events
        /// DontDestroyOnLoad
        /// </summary>
        public void DoOnStart()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnDisable here.
        /// Example:
        /// Unsubscribe from Events
        /// </summary>
        public void DoOnDisable()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnDestroy here.
        /// Example:
        /// Dispose of any Objects
        /// </summary>
        public void DoOnDestroy()
        {
        }

        #endregion
    }
}