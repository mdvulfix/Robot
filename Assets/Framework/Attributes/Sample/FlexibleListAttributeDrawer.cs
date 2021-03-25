using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;


namespace Robot.Attributes
{
	[CustomEditor(typeof(BotCanon), true, isFallback = true)]
    [CanEditMultipleObjects]
    public class FlexibleListAttributeDrawer : Editor
    {
        
        //private List<SerializedProperty> Properties {get; } = new List<SerializedProperty>();
        
        //private FlexibleListAttribute   _attribute;
        //private List<FieldInfo>         _objectFields;
        
        private ReorderableList         _listProperty;

        //private ActionMoveTranslate _bot;
        
        private void OnEnable()
        {
            
            //GetObjectFields();
           // if(target == null)
            //    return;
            
            //_bot = (ActionMoveTranslate)target;
            //var property = this.serializedObject.FindProperty("DataList");
            //_listProperty = new ReorderableList(property.serializedObject, property ,true, true, true, true);
        
            //Repaint();


        
        }

        private void OnDisable()
        {

        }
        
        private void Awake()
        {





        }

        public override void OnInspectorGUI()
        {
            //this.serializedObject.Update();

            //DrawDefaultInspector();
            //_listProperty.DoLayoutList();
            //var property = _listProperty.serializedProperty;
            //property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, property.displayName);
            //if (property.isExpanded)
            //{
            //    _listProperty.DoLayoutList();
            //}

            //this.serializedObject.ApplyModifiedProperties();
            
        }



 #region private methods
     
    /*
    private void GetObjectFields()
    {
            _objectFields = target.GetType()
				.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
				.ToList();
    }  
    
    private bool DrawDefaultInspectorIfNoChanges()
    {
        bool trueOrFalse = false;

        if (Properties.Count == 0)
        {
            DrawDefaultInspector();
            return trueOrFalse = true;
        }

        return trueOrFalse;
            
    }
 
    */
 #endregion       
  
    }



}
