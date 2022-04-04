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
        }

        #endregion

        #region METHODS

        #endregion
    }
}