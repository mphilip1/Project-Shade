using UnityEngine;
using UnityEditor;

using System;

[CustomPropertyDrawer(typeof(ItemText))]
public class ItemTextDrawer : PropertyDrawer {

    private static GUIContent[] labels;

    static ItemTextDrawer() {
        State[] states = Enum.GetValues(typeof(State)) as State[];

        labels = new GUIContent[states.Length];

        for(int i = 0; i < labels.Length; i++)
        {
            labels[i] = new GUIContent(states[i].ToString());
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float result = 0;
        result += EditorGUIUtility.singleLineHeight;

        if (property.isExpanded)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                result += EditorGUIUtility.singleLineHeight + 2;
            }
        }

        return result;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = EditorGUIUtility.singleLineHeight;

        if (EditorGUI.PropertyField(position, property, label, false))
        {
            EditorGUI.indentLevel++;
            {
                SerializedProperty textProperty = property.FindPropertyRelative("text");

                if (textProperty.arraySize != labels.Length)
                {
                    textProperty.arraySize = labels.Length;
                }

                for (int i = 0; i < textProperty.arraySize; i++)
                {
                    position.y += EditorGUIUtility.singleLineHeight + 2;
                    EditorGUI.PropertyField(position, textProperty.GetArrayElementAtIndex(i), labels[i]);
                }
            }
            EditorGUI.indentLevel--;
        }
    }

}
