using Rogue.Attributes;
using Rogue.General.Entity;
using Rogue.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rogue.Player
{
    public class PlayerEntity : EntityBase
    {
        #region VARIABLES

        [Header("Behaviours")]
        public AttackBehaviour AttackBehaviour;
        public MovementBehaviour MovementBehaviour;

        [Header("Controllers")]
        public AnimationController AnimationController;

        [Header("Health")]
        public EntityHealth Health;
        public EntityArmor Armor;

        [Header("Input Actions")]
        public InputActionReference MovementAction;
        public InputActionReference InteractionAction;

        [Header("Entity Flags")]
        public bool IsMoving;
        public bool IsAttacking;

        [Header("Input Flags")]
        public Vector2 InputAxis = Vector2.zero;
        public bool Interact = false;
        public bool Swap = false;
        public bool Attack = false;

        private PlayerControls _playerControls;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            DoOnAwake();
        }

        private void OnEnable()
        {
            DoOnEnable();
        }

        private void Update()
        {
            ProcessInput();
        }

        private void FixedUpdate()
        {
            MovementBehaviour.Movement(InputAxis);
        }

        private void LateUpdate()
        {
            DoAttack();
            SwapWeapon();
        }

        private void OnDisable()
        {
            DoOnDisable();
        }

        private void OnDestroy()
        {
            DoOnDestroy();
        }

        #endregion

        #region PROCESS INPUT METHODS

        private void ProcessInput()
        {
            InputAxis.x = Input.GetAxisRaw("Horizontal");
            InputAxis.y = Input.GetAxisRaw("Vertical");
            Swap = Input.GetKeyDown(KeyCode.R);
            Attack = Input.GetButtonDown("Fire1");
            Interact = Input.GetKeyDown(KeyCode.E);
        }

        #endregion

        #region BEHAVIOUR METHODS

        private void DoAttack()
        {
            if (Attack) AttackBehaviour.Attack();
        }

        private void SwapWeapon()
        {
            if (Swap) AttackBehaviour.SwapWeapons();
        }

        #endregion

        #region TAKE DAMAGE METHODS

        public override void TakeDamage(float damage)
        {
            if (Armor.HasArmor)
            {
                float result = Armor.CurrentArmor - damage;
                Armor.LoseArmor(damage);
                EventsManager.Instance.OnUpdateArmor(Armor.CurrentArmorPercentage);
                if (result < 0) Health.LoseHealth(Mathf.Abs(result));
                EventsManager.Instance.OnUpdateHealth(Health.CurrentHealthPercentage);
            }

            else if (Health.HasHealth)
            {
                Health.LoseHealth(damage);
                EventsManager.Instance.OnUpdateHealth(Health.CurrentHealthPercentage);
            }

            if (Health.HasHealth) return;
            EventsManager.Instance.OnPlayerDeath();
            AnimationController.OnDeath();
        }

        #endregion

        #region ENTITY METHODS

        public override void Activate()
        {
            AnimationController.ResetAnimator();
            Health.ResetHealth();
            Armor.ResetArmor();
            EventsManager.Instance.OnUpdateHealth(Health.CurrentHealthPercentage);
            EventsManager.Instance.OnUpdateArmor(Armor.CurrentArmorPercentage);
            transform.position = Vector3.zero;
        }

        #endregion

        #region UNITY EVENT METHODS

        public override void DoOnAwake()
        {
            _playerControls = new PlayerControls();
        }

        public override void DoOnEnable()
        {
            _playerControls.Enable();
            MovementAction.action.Enable();
            InteractionAction.action.Enable();
        }

        public override void DoOnDisable()
        {
            _playerControls.Disable();
            MovementAction.action.Disable();
            InteractionAction.action.Disable();
        }

        public override void DoOnDestroy()
        {
            _playerControls.Dispose();
            MovementAction.action.Dispose();
            InteractionAction.action.Dispose();

            EventsManager.Instance.OnUnregisterPlayer();
        }

        #endregion
    }
}