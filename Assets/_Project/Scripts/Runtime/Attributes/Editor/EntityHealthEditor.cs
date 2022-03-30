#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Rogue.Attributes
{
    [CustomEditor(typeof(EntityHealth))]
    public class EntityHealthEditor : Editor
    {
        #region VARIABLES

        private EntityHealth _target;
        private float _getHealthAmount = 2;
        private float _loseHealthAmount = 2;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as EntityHealth;
        }

        public override void OnInspectorGUI()
        {
            using (EditorGUILayout.HorizontalScope horizontalScope = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button($"Get Health +{_getHealthAmount}"))
                {
                    _target.GetHealth(_getHealthAmount);
                }

                if (GUILayout.Button($"Lose Health -{_loseHealthAmount}"))
                {
                    _target.LoseHealth(_getHealthAmount);
                }

                if (GUILayout.Button("Reset Health"))
                {
                    _target.ResetHealth();
                }
            }

            base.OnInspectorGUI();
        }

        #endregion

        #region METHODS

        #endregion
    }
}
#endif