using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IntRangeSliderAttribute))]
public class IntRangeSliderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        int originalIndentLevel = EditorGUI.indentLevel;
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        EditorGUI.indentLevel = 0;

        SerializedProperty minProperty = property.FindPropertyRelative("_min");
        SerializedProperty maxProperty = property.FindPropertyRelative("_max");

        int minValue = minProperty.intValue;
        int maxValue = maxProperty.intValue;

        float fieldWidth = position.width * 0.25f - 4f;
        float sliderWidth = position.width * 0.5f;

        position.width = fieldWidth;
        minValue = EditorGUI.IntField(position, minValue);

        position.x += fieldWidth + 4f;
        position.width = sliderWidth;

        IntRangeSliderAttribute rangeLimits = (IntRangeSliderAttribute)attribute;

        float minValueFloat = (float)minValue;
        float maxValueFloat = (float)maxValue;

        EditorGUI.MinMaxSlider(position, ref minValueFloat, ref maxValueFloat, (float)rangeLimits.Min, (float)rangeLimits.Max);

        minValue = Mathf.RoundToInt(minValueFloat);
        maxValue = Mathf.RoundToInt(maxValueFloat);

        position.x += sliderWidth + 4f;
        position.width = fieldWidth;
        maxValue = EditorGUI.IntField(position, maxValue);

        minValue = Mathf.Clamp(minValue, rangeLimits.Min, maxValue);
        maxValue = Mathf.Clamp(maxValue, minValue, rangeLimits.Max);

        minProperty.intValue = minValue;
        maxProperty.intValue = maxValue;

        EditorGUI.EndProperty();
        EditorGUI.indentLevel = originalIndentLevel;
    }
}
