using UnityEngine;

namespace CyberJellyFish
{
    public struct Vectors
    {
        #region VARIABLES

        private static Vector3 _moveTowardsVector = Vector3.zero;
        private static Vector3 _lerpVector = Vector3.zero;

        #endregion

        #region METHODS

        public static float Distance(Vector3 a, Vector3 b)
        {
            return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z));
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }

        public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            float num1 = target.x - current.x;
            float num2 = target.y - current.y;
            float num3 = target.z - current.z;
            float num4 = num1 * num1 + num2 * num2 +
                         num3 * num3;

            if (num4 == 0.0 || maxDistanceDelta >= 0.0 && num4 <= maxDistanceDelta * maxDistanceDelta)
                return target;

            float num5 = Mathf.Sqrt(num4);

            _moveTowardsVector.x = current.x + num1 / num5 * maxDistanceDelta;
            _moveTowardsVector.y = current.y + num2 / num5 * maxDistanceDelta;
            _moveTowardsVector.z = current.z + num3 / num5 * maxDistanceDelta;
            return _moveTowardsVector;
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            t = Mathf.Clamp01(t);
            _lerpVector.x = a.x + (b.x - a.x) * t;
            _lerpVector.y = a.y + (b.y - a.y) * t;
            _lerpVector.z = a.z + (b.z - a.z) * t;

            return _lerpVector;
        }

        #endregion
    }
}