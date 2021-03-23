using System.Collections;
using UnityEngine;
using UnityEditor;

namespace Robot
{
    [CustomPropertyDrawer(typeof(MyCustomAttribute))]
    public class MyCustomAttributeDrawer : PropertyDrawer
    {

        public string value = null;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent labal)
        {

            value = property.intValue.ToString();
            GUI.Label(position, property.displayName + " : " + value);
            
            /*
            obj = (GameObject)EditorGUI.ObjectField(position, property.displayName, obj, typeof(GameObject));
            
            if (obj)
                if (GUI.Button(new Rect(3, 25, position.width - 6, 20), "Check Dependencies"))
                    Selection.objects = EditorUtility.CollectDependencies(new GameObject[] {obj});
                else
                    EditorGUI.LabelField(new Rect(3, 25, position.width - 6, 20), "Missing:", "Select an object first");



            */

            /*
            MyCustomAttribute _propertyAttribute = attribute as MyCustomAttribute;           
            
            EditorGUI.BeginProperty(position, labal, property);
            
            EditorGUI.ObjectField(position,property.FindPropertyRelative("NewMoveAction"), GUIContent.none);
        
            EditorGUI.EndProperty();
            */
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);

        }


    }
}
