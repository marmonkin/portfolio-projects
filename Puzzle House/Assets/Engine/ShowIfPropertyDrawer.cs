#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = (ShowIfAttribute)attribute;
        SerializedProperty conditionalProperty = property.serializedObject.FindProperty(showIf.conditionalField);

        if (conditionalProperty != null && conditionalProperty.boolValue)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = (ShowIfAttribute)attribute;
        SerializedProperty conditionalProperty = property.serializedObject.FindProperty(showIf.conditionalField);

        if (conditionalProperty != null && conditionalProperty.boolValue)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        return 0;
    }
}
#endif