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
            StartCoroutine(AttackRoutine());
        }

        private IEnumerator AttackRoutine()
        {
            WaitForSeconds attackDelay = new WaitForSeconds(_attackSpeed);
            if (!IsSwordEquipped) yield break;
            if (_playerEntity.IsAttacking) yield break;
            _playerEntity.IsAttacking = IsAttacking = true;
            AnimationController.OnAttack();
            yield return attackDelay;
            _playerEntity.IsAttacking = IsAttacking = false;
        }

        #endregion
    }
}