using Rogue.Player;
using Rogue.Serializables;
using UnityEngine;

namespace Rogue.Items
{
    public class WeaponItem : MonoBehaviour
    {
        #region VARIABLES

        [Header("Weapon Properties")]
        public Weapon WeaponData;

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<AttackBehaviour>().EquipWeapon(WeaponData);
            Destroy(gameObject);
        }

        #endregion

        #region METHODS

        #endregion
    }
}