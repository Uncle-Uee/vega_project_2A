using CyberJellyFish.Utility;
using Rogue.Attributes;
using Rogue.General.Entity;
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

        [Header("Health")]
        public EntityHealth Health;

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

            #region BEHAVIOURS

            DoAttack();
            SwapWeapon();

            #endregion
        }

        private void FixedUpdate()
        {
            MovementBehaviour.Movement(InputAxis);
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

        #region PROCESS INPUT

        private void ProcessInput()
        {
            InputAxis.x = Input.GetAxisRaw("Horizontal");
            InputAxis.y = Input.GetAxisRaw("Vertical");
            Swap = Input.GetKeyDown(KeyCode.R);
            Attack = Input.GetButtonDown("Fire1");
            Interact = Input.GetKeyDown(KeyCode.E);
        }

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
            Health.LoseHealth(damage);
            EventsManager.Instance.OnUpdateHealth(Mathf.Clamp01(MathUtility.GetPercentageFromValue(Health.CurrentHealth, 0, Health.CurrentMaxHealth)));
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
        }

        #endregion
    }
}