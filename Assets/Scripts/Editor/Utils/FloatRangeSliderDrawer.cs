using UnityEditor;
using UnityEngine;

namespace Utils
{
    [CustomPropertyDrawer(typeof(FloatRangeSliderAttribute))]
    public class FloatRangeSliderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Generic || property.type != nameof(FloatRange))
            {
                EditorGUI.LabelField(position, "Exception: Use FloatRangeSliderAttribute with FloatRange");
                return;
            }

            int originalIndentLevel = EditorGUI.indentLevel;
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.indentLevel = 0;

            SerializedProperty minProperty = property.FindPropertyRelative("_min");
            SerializedProperty maxProperty = property.FindPropertyRelative("_max");

            float minValue = minProperty.floatValue;
            float maxValue = maxProperty.floatValue;

            float fieldWidth = position.width * 0.25f - 4f;
            float sliderWidth = position.width * 0.5f;

            position.width = fieldWidth;
            minValue = EditorGUI.FloatField(position, minValue);

            position.x += fieldWidth + 4f;
            position.width = sliderWidth;

            FloatRangeSliderAttribute rangeLimits = (FloatRangeSliderAttribute)attribute;
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeLimits.Min, rangeLimits.Max);

            position.x += sliderWidth + 4f;
            position.width = fieldWidth;
            maxValue = EditorGUI.FloatField(position, maxValue);

            minValue = Mathf.Clamp(minValue, rangeLimits.Min, maxValue);
            maxValue = Mathf.Clamp(maxValue, minValue, rangeLimits.Max);

            minProperty.floatValue = minValue;
            maxProperty.floatValue = maxValue;

            EditorGUI.EndProperty();
            EditorGUI.indentLevel = originalIndentLevel;
        }
    }
}