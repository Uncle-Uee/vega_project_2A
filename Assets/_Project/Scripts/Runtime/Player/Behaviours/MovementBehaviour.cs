using UnityEngine;

namespace Rogue.Player
{
    public class MovementBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public Rigidbody2D Rigidbody2D;

        [Header("Controllers")]
        public AnimationController AnimationController;

        [Header("Movement Properties")]
        [Range(1f, 25f)]
        public float Speed = 1f;
        [Range(0f, 1f)]
        public float DiagonalSpeedPercentage = 0.75f;
        [Range(0f, 0.5f)]
        public float SmoothTime = 0.1f;

        [Header("Movement Status")]
        public bool IsMoving = false;

        private PlayerEntity _playerEntity;

        private Vector2 _target;
        private Vector2 _current;
        private Vector2 _velocity;
        private Vector2 _direction = Vector2.down;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            _playerEntity = GetComponent<PlayerEntity>();
        }

        #endregion

        #region METHODS

        public void Movement(Vector2 inputAxis)
        {
            if (_playerEntity.IsAttacking)
            {
                Rigidbody2D.velocity = Vector2.zero;
                return;
            }

            CheckInputForMovement(inputAxis);
            CheckInputForDirection(inputAxis);

            _velocity = Rigidbody2D.velocity;

            _target.x = inputAxis.x;
            _target.y = inputAxis.y;

            if (Mathf.Abs(inputAxis.x) > 0 && Mathf.Abs(inputAxis.y) > 0)
            {
                _target *= Speed * DiagonalSpeedPercentage;
            }
            else
            {
                _target *= Speed;
            }

            Rigidbody2D.velocity = Vector2.SmoothDamp(_velocity, _target, ref _current, SmoothTime);
        }

        #endregion

        #region ORIENTATION METHODS

        private void CheckInputForDirection(Vector2 inputAxis)
        {
            if (_playerEntity.IsAttacking) return;

            if (Mathf.Abs(inputAxis.x) > 0)
            {
                _direction.x = inputAxis.x;
                _direction.y = 0;
            }
            else if (Mathf.Abs(inputAxis.y) > 0)
            {
                _direction.y = inputAxis.y;
                _direction.x = 0;
            }

            AnimationController.SetXDirection(_direction.x);
            AnimationController.SetYDirection(_direction.y);
        }

        private void CheckInputForMovement(Vector2 inputAxis)
        {
            _playerEntity.IsMoving = IsMoving = inputAxis != Vector2.zero;
            AnimationController.SetIsMoving(inputAxis != Vector2.zero);
        }

        #endregion
    }
}