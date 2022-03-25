using Rogue.Data;
using Rogue.General.Entity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rogue.Player
{
    public class PlayerEntity : EntityBase
    {
        #region VARIABLES

        [Header("Behaviours")]
        public MovementBehaviour MovementBehaviour;

        [Header("Input Actions")]
        public InputActionReference MovementAction;
        public InputActionReference InteractionAction;
        public PlayerControls PlayerControls;


        [Header("Save Data")]
        public GameData GameData;

        [Header("Debug Values")]
        public Vector2 InputAxis = Vector2.zero;
        public bool Interact = false;
        public bool Save = false;
        public bool Load = false;

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

            if (Save)
            {
                GameData.Save(gameObject.name);
            }

            if (Load)
            {
                GameData.Load(gameObject.name);
            }
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

            Save = Input.GetKeyDown(KeyCode.O);
            Load = Input.GetKeyDown(KeyCode.P);
        }

        #endregion

        #region UNITY EVENT METHODS

        public override void DoOnAwake()
        {
            PlayerControls = new PlayerControls();
        }

        public override void DoOnEnable()
        {
            PlayerControls.Enable();
            MovementAction.action.Enable();
            InteractionAction.action.Enable();
        }

        public override void DoOnDisable()
        {
            PlayerControls.Disable();
            MovementAction.action.Disable();
            InteractionAction.action.Disable();
        }

        public override void DoOnDestroy()
        {
            PlayerControls.Dispose();
            MovementAction.action.Dispose();
            InteractionAction.action.Dispose();
        }

        #endregion
    }
}