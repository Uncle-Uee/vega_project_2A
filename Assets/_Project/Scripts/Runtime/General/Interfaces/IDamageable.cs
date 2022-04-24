using System.Collections;

namespace Rogue.General
{
    public interface IDamageable
    {
        #region METHODS

        void TakeDamage(float damage);

        void TakeDamageOverTime(float damage, float time, int n);

        IEnumerable TakeDamageRoutine(float damage, float time, int n);

        #endregion
    }
}