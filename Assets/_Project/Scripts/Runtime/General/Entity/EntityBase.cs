using System.Collections;
using UnityEngine;

namespace Rogue.General.Entity
{
    public abstract class EntityBase : MonoBehaviour, IDamageable
    {
        #region STATE METHODS

        /// <summary>
        /// Activate Object
        /// </summary>
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivate Object
        /// </summary>
        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Destroy Object
        /// </summary>
        public virtual void DestroyInstance()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// Create a Clone of this Object
        /// </summary>
        public virtual Object Clone()
        {
            return Instantiate(this);
        }

        #endregion

        #region ENTITY METHODS

        public virtual void TakeDamage(float damage)
        {
            //ToDo : Simple Implementation
        }

        public virtual void TakeDamageOverTime(float damage, float time, int n)
        {
        }

        public virtual IEnumerable TakeDamageRoutine(float damage, float time, int n)
        {
            yield return null;
        }

        #endregion

        #region EVENT METHODS

        /// <summary>
        /// Do anything required to be called during Awake here.
        /// Example:
        /// Initialization of Objects, Fields and Properties
        /// Subscribe to Events
        /// </summary>
        public virtual void DoOnAwake()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnEnable here.
        /// Example:
        /// Reset Properties, Objects and Fields
        /// Subscribe to Events
        /// </summary>
        public virtual void DoOnEnable()
        {
        }

        /// <summary>
        /// Do anything required to be called during Start here.
        /// Example:
        /// Initialize Objects
        /// Subscribe to Events
        /// DontDestroyOnLoad
        /// </summary>
        public virtual void DoOnStart()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnDisable here.
        /// Example:
        /// Unsubscribe from Events
        /// </summary>
        public virtual void DoOnDisable()
        {
        }

        /// <summary>
        /// Do anything required to be called during OnDestroy here.
        /// Example:
        /// Dispose of any Objects
        /// </summary>
        public virtual void DoOnDestroy()
        {
        }

        #endregion
    }
}