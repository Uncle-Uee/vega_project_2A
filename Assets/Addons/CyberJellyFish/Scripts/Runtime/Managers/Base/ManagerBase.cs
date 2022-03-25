using UnityEngine;

namespace CyberJellyFish.Managers
{
    public abstract class ManagerBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region VARIABLES

        [Header("Manager Settings")]
        [Tooltip("Do Not Destroy this Object when Loading Scenes.")]
        public bool IsPersistent = false;
        [Tooltip("Call Initialize Singleton to create a Singleton Instance, only works if DoNotDestroyOnLoad is True.")]
        public bool IsSingleton = false;

        private static T _instance;
        private readonly object _lock = new object();

        #endregion

        #region PROPERTIES

        public static T Instance
        {
            get
            {
                if (_instance) return _instance;
                Debug.LogWarning($"This {_instance.name} is not Initialized. Please use the InitializeSingleton method in Awake.");
                return null;
            }
        }

        #endregion

        #region UNITY METHODS

        public virtual void Awake()
        {
            MakePersistent();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Make this Object Persist regardless of Scene Loading.
        /// </summary>
        private void MakePersistent()
        {
            if (!IsPersistent) return;
            if (transform.parent != null) transform.parent = null;
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Initialize the Singleton Instance. Call during Awake!
        /// </summary>
        /// <param name="instance"></param>
        public void InitializeSingleton(T instance)
        {
            if (!IsPersistent || !IsSingleton) return;

            lock (_lock)
            {
                if (_instance) return;

                T[] instances = FindObjectsOfType<T>();
                int count = instances.Length;
                if (count == 0) return;
                if (count == 1)
                {
                    _instance = instance;
                    return;
                }

                for (int i = 1; i < count; i++)
                {
                    Destroy(instances[i].gameObject);
                }

                _instance = instance;
            }
        }

        #endregion
    }
}