#if (UNITY_EDITOR) 
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Waypoint))]
public class WaypointDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var amountRect_1 = new Rect(position.x, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);
        var amountRect_2 = new Rect(position.x + position.width / 2, position.y, position.width / 2, EditorGUIUtility.singleLineHeight);

        var amountRect_3 = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 7, position.width / 2, EditorGUIUtility.singleLineHeight);
        var amountRect_4 = new Rect(position.x + position.width / 2 + 20, position.y + EditorGUIUtility.singleLineHeight + 7, position.width / 2, EditorGUIUtility.singleLineHeight);

        var target1 = new Rect(position.x + position.width / 2, position.y + EditorGUIUtility.singleLineHeight * 2 + 7, position.width / 2, EditorGUIUtility.singleLineHeight);
        var target2 = new Rect(position.x + position.width / 2, position.y + EditorGUIUtility.singleLineHeight * 3 + 10, position.width / 2, EditorGUIUtility.singleLineHeight);
        var target3 = new Rect(position.x + position.width / 2, position.y + EditorGUIUtility.singleLineHeight * 4 + 13, position.width / 2, EditorGUIUtility.singleLineHeight);
        var target4 = new Rect(position.x + position.width / 2, position.y + EditorGUIUtility.singleLineHeight * 5 + 16, position.width / 2, EditorGUIUtility.singleLineHeight);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUIUtility.labelWidth = 40f;
        EditorGUI.PropertyField(amountRect_1, property.FindPropertyRelative("name"), new GUIContent("Name"));
        EditorGUI.PropertyField(amountRect_2, property.FindPropertyRelative("index"), new GUIContent(" Index"));
        EditorGUIUtility.labelWidth = 60f;
        EditorGUI.PropertyField(amountRect_3, property.FindPropertyRelative("waypointTransform"), new GUIContent("Transform"));

        property.isExpanded = EditorGUI.Foldout(amountRect_4, property.isExpanded, "Targets");
        property.FindPropertyRelative("targets");
        if (property.isExpanded)
        {
            EditorGUI.PropertyField(target1, property.FindPropertyRelative("targets.left"), new GUIContent(" Left"));
            EditorGUI.PropertyField(target2, property.FindPropertyRelative("targets.right"), new GUIContent(" Right"));
            EditorGUI.PropertyField(target3, property.FindPropertyRelative("targets.up"), new GUIContent(" Up"));
            EditorGUI.PropertyField(target4, property.FindPropertyRelative("targets.down"), new GUIContent(" Down"));
        }

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return property.isExpanded ? 18f * 7 : 52;
    }
}
#endif