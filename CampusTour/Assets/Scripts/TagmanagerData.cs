using UnityEditor;
using UnityEngine;

// Custom property attribute for tagging
public class TagArrayAttribute : PropertyAttribute { }

// Custom property drawer for the tag array
[CustomPropertyDrawer(typeof(TagArrayAttribute))]
public class TagArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            EditorGUI.BeginProperty(position, label, property);
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
            EditorGUI.EndProperty();
        }
       
        else
        {
            EditorGUI.LabelField(position, label, "Use TagArray with string or string array.");
        }
    }
}

// Manager for tags, to get all tags used in the project
[CreateAssetMenu(fileName = "TagManagerData", menuName = "Custom/Tag Manager Data")]
public class TagManagerData : ScriptableObject
{
    [TagArray]
    public string[] tags;
}