using System.Collections;
using Rogue.General;
using Rogue.Serializables;
using UnityEngine;

namespace Rogue.Player
{
    public class AttackBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Header("Controllers")]
        public AnimationController AnimationController;

        [Header("Weapons")]
        public Weapon PrimaryWeapon;
        public Weapon SecondaryWeapon;

        [Header("Attack Statuses")]
        public bool IsSwordEquipped = false;
        public bool UsingPrimary = true;
        public bool IsAttacking = false;

        private PlayerEntity _playerEntity;
        private readonly float _attackSpeed = 0.3f;

        #endregion

        #region PROPERTIES

        public float AttackPower => PrimaryWeapon.AttackPower;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            _playerEntity = GetComponent<PlayerEntity>();
        }

        #endregion

        #region METHODS

        public void SwapWeapons()
        {
            if (SecondaryWeapon == null) return;
            (PrimaryWeapon, SecondaryWeapon) = (SecondaryWeapon, PrimaryWeapon);
            UsingPrimary = !UsingPrimary;
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (PrimaryWeapon == null && !IsSwordEquipped)
            {
                PrimaryWeapon = weapon;
                UsingPrimary = true;
                IsSwordEquipped = true;
            }
            else if (SecondaryWeapon == null) SecondaryWeapon = weapon;
        }

        public void Attack()
        {
            if (IsAttacking) return;
            _playerEntity.IsAttacking = IsAttacking = true;
            AnimationController.SetIsAttacking(IsAttacking);
        }

        public void CancelAttack()
        {
            _playerEntity.IsAttacking = IsAttacking = false;
            AnimationController.SetIsAttacking(IsAttacking);
            print("Stop Attacking");
        }

        #endregion
    }
}