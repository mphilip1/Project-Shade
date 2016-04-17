using UnityEngine;
using UnityEditor;

using System;

using Rotorz.ReorderableList;

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
            SerializedProperty contentProperty = property.FindPropertyRelative("content");

            if (contentProperty.arraySize != labels.Length)
            {
                contentProperty.arraySize = labels.Length;
            }

            for (int i = 0; i < labels.Length; i++)
            {
                result += EditorGUI.GetPropertyHeight(contentProperty.GetArrayElementAtIndex(i)) + 2;
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
                SerializedProperty contentProperty = property.FindPropertyRelative("content");

                if (contentProperty.arraySize != labels.Length)
                {
                    contentProperty.arraySize = labels.Length;
                }

                for (int i = 0; i < contentProperty.arraySize; i++)
                {
                    SerializedProperty elementProperty = contentProperty.GetArrayElementAtIndex(i);
                    float height = EditorGUI.GetPropertyHeight(elementProperty);

                    position.y += position.height + 2;
                    position.height = height;

                    EditorGUI.PropertyField(position, elementProperty, labels[i]);
                }
            }
            EditorGUI.indentLevel--;
        }
    }
}

[CustomPropertyDrawer(typeof(ItemText.Content))]
public class ItemTextContentDrawer : PropertyDrawer
{
    private const ReorderableListFlags ListFlags = ReorderableListFlags.ShowIndices;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float result = 0;
        result += EditorGUIUtility.singleLineHeight;

        if (property.isExpanded)
        {
            SerializedProperty textsProperty = property.FindPropertyRelative("text");
            result += ReorderableListGUI.CalculateListFieldHeight(textsProperty, ListFlags) + 2;
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
                textProperty.isExpanded = true;

                position.y += EditorGUIUtility.singleLineHeight + 2;
                position.height = ReorderableListGUI.CalculateListFieldHeight(textProperty, ListFlags);
                
                ReorderableListGUI.ListFieldAbsolute(position, textProperty);
            }
            EditorGUI.indentLevel--;
        }
    }
}
