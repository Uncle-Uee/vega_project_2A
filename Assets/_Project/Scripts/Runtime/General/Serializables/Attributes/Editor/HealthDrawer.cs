#if UNITY_EDITOR
using Rogue.Serializables;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Health))]
public class HealthDrawer : PropertyDrawer
{
    #region VARIABLES

    private float _rows = 3;

    #endregion

    #region UNITY METHODS

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect maxHealth = new Rect(position.x, position.y, position.width, position.height / _rows);
        Rect currentMaxHealth = new Rect(position.x, position.y + 20, position.width, position.height / _rows);
        Rect currentHealth = new Rect(position.x, position.y + 40, position.width, position.height / _rows);

        EditorGUI.PropertyField(maxHealth, property.FindPropertyRelative(nameof(Health.MaxHealth)), new GUIContent(nameof(Health.MaxHealth)));
        EditorGUI.PropertyField(currentMaxHealth, property.FindPropertyRelative(nameof(Health.CurrentMaxHealth)),
            new GUIContent(nameof(Health.CurrentMaxHealth)));
        EditorGUI.PropertyField(currentHealth, property.FindPropertyRelative(nameof(Health.CurrentHealth)), new GUIContent(nameof(Health.CurrentHealth)));

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * _rows;
    }

    #endregion

    #region METHODS

    #endregion
}
#endif