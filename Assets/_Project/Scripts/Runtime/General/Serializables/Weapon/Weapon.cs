using System;
using UnityEngine;

namespace Rogue.Serializables
{
    [Serializable]
    public class Weapon
    {
        #region VARIABLES

        [Header("Attack Properties")]
        public float AttackPower;

        #endregion
    }
}