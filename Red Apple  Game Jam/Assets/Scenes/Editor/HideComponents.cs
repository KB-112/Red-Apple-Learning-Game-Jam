using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.PlayerSettings;

[CustomPropertyDrawer(typeof(ComponentsInspector))]
public class ComponentsInspectorDrawer : PropertyDrawer
{

    void OnEnable()
    {
        ComponentsInspector componentsInspector = (ComponentsInspector)attribute;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        base.OnGUI(position, property, label);
        EditorGUI.BeginProperty(position, label, property);
        var visblity = new PropertyField(property.FindPropertyRelative("visiblity"));
        EditorGUI.EndProperty();
    }
    

    
}
