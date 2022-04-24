using Rogue.General;
using UnityEngine;

namespace Rogue.Items
{
    public class MilkItem : MonoBehaviour
    {
        #region VARIABLES

        [Header("Health Properties")]
        public float Health = 5;

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<IHealable>()?.GetHealth(Health);
            
            Destroy(gameObject);
        }

        #endregion

        #region METHODS

        #endregion
    }
}