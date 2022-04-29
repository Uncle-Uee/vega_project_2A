using Rogue.General;
using Rogue.General.Entity;
using UnityEngine;

namespace Rogue.Traps
{
    public class SpikeTrap : MonoBehaviour
    {
        #region VARIABLES

        [Header("Trap Properties")]
        public float Damage = 1f;

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
            other.GetComponent<IDamageable>()?.TakeDamage(Damage);
            
            // ?. => Null Propagation
            // Checks the left side if it is null.
            // If it is not null, do everything on the right
        }

        #endregion

        #region METHODS

        #endregion
    }
}