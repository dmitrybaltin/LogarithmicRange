using UnityEngine;
using UnityEditor;

namespace Baltin.LogarithmicRange
{
    public class LogarithmicRangeAttribute : PropertyAttribute
    {
        public float min;
        public float max;

        public LogarithmicRangeAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }

    [CustomPropertyDrawer(typeof(LogarithmicRangeAttribute))]
    public class LogarithmicRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Get the custom attribute for the logarithmic range
            LogarithmicRangeAttribute logRange = (LogarithmicRangeAttribute)attribute;

            // Calculate the logarithmic range based on the provided min and max values
            float minLog = Mathf.Log10(logRange.min);
            float maxLog = Mathf.Log10(logRange.max);

            // Convert the current property value to a logarithmic scale
            float logValue = Mathf.Log10(property.floatValue);

            // Split the available space into areas for the label, slider, and value input
            float labelWidth = EditorGUIUtility.labelWidth; // Get the width of the label
            Rect labelRect = new Rect(position.x, position.y, labelWidth, position.height); // Space for the label
            Rect sliderRect = new Rect(position.x + labelWidth + 5, position.y, position.width - labelWidth - 50,
                position.height); // Space for the slider
            Rect valueRect =
                new Rect(position.x + position.width - 45, position.y, 45,
                    position.height); // Space for the value input field

            // Display the label with dynamic width
            EditorGUI.PrefixLabel(labelRect, label);

            // Display the slider, which will adjust the logValue between the minLog and maxLog values
            logValue = GUI.HorizontalSlider(sliderRect, logValue, minLog, maxLog);

            // Convert the log value back to the original scale and update the property value
            property.floatValue = Mathf.Pow(10, logValue);

            // Create a field for the user to edit the original value directly (the edit-box)
            EditorGUI.BeginChangeCheck();
            float newValue = EditorGUI.FloatField(valueRect, property.floatValue);

            // If the value has changed, update the property value
            if (EditorGUI.EndChangeCheck())
            {
                property.floatValue = newValue;
            }
        }
    }
}