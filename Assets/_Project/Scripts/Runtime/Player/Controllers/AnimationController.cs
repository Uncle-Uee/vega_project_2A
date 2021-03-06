using UnityEngine;

namespace Rogue.Player
{
    public class AnimationController : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public Animator Animator;

        private readonly int XDirection = Animator.StringToHash("XDirection");
        private readonly int YDirection = Animator.StringToHash("YDirection");
        private readonly int IsMoving = Animator.StringToHash("IsMoving");
        private readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private readonly int Attack = Animator.StringToHash("Attack");
        private readonly int Death = Animator.StringToHash("Death");
        private readonly int PickupItem = Animator.StringToHash("PickupItem");
        private readonly int SpecialArt_1 = Animator.StringToHash("SpecialArt_1");
        private readonly int SpecialArt_2 = Animator.StringToHash("SpecialArt_2");

        #endregion

        #region UNITY METHODS

        #endregion

        #region METHODS

        public void SetXDirection(float value)
        {
            Animator.SetFloat(XDirection, value);
        }

        public void SetYDirection(float value)
        {
            Animator.SetFloat(YDirection, value);
        }

        public void SetIsMoving(bool value)
        {
            Animator.SetBool(IsMoving, value);
        }

        public void OnAttack()
        {
            Animator.SetTrigger(Attack);
        }

        public void SetIsAttacking(bool value)
        {
            Animator.SetBool(IsAttacking, value);
        }

        public void OnDeath()
        {
            Animator.SetTrigger(Death);
        }

        public void ResetAnimator()
        {
            Animator.Rebind();
            Animator.Update(0);
        }

        #endregion
    }
}