#if UNITY_EDITOR
using Rogue.Serializables;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Armor))]
public class ArmorDrawer : PropertyDrawer
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

        Rect maxArmor = new Rect(position.x, position.y, position.width, position.height / _rows);
        Rect currentMaxArmor = new Rect(position.x, position.y + 20, position.width, position.height / _rows);
        Rect currentArmor = new Rect(position.x, position.y + 40, position.width, position.height / _rows);

        EditorGUI.PropertyField(maxArmor, property.FindPropertyRelative(nameof(Armor.MaxArmor)), new GUIContent(nameof(Armor.MaxArmor)));
        EditorGUI.PropertyField(currentMaxArmor, property.FindPropertyRelative(nameof(Armor.CurrentMaxArmor)),
            new GUIContent(nameof(Armor.CurrentMaxArmor)));
        EditorGUI.PropertyField(currentArmor, property.FindPropertyRelative(nameof(Armor.CurrentArmor)), new GUIContent(nameof(Armor.CurrentArmor)));

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