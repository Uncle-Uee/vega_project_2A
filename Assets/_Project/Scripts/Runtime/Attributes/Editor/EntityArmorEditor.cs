#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Rogue.Attributes
{
    [CustomEditor(typeof(EntityArmor))]
    public class EntityArmorEditor : Editor
    {
        #region VARIABLES

        private EntityArmor _target;
        private float _getArmorAmount = 2;
        private float _loseArmorAmount = 2;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as EntityArmor;
        }

        public override void OnInspectorGUI()
        {
            using (EditorGUILayout.HorizontalScope horizontalScope = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button($"Get Health +{_getArmorAmount}"))
                {
                    _target.GetArmor(_getArmorAmount);
                }

                if (GUILayout.Button($"Lose Health -{_loseArmorAmount}"))
                {
                    _target.LoseArmor(_getArmorAmount);
                }

                if (GUILayout.Button("Reset Health"))
                {
                    _target.ResetArmor();
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