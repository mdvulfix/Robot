using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;


namespace Robot.Attributes
{
	[CustomEditor(typeof(ActionMoveTranslate), true, isFallback = true)]
    public class FlexibleListAttributeDrawer : Editor
    {
        
        private List<SerializedProperty> Properties {get; } = new List<SerializedProperty>();
        
        private FlexibleListAttribute   _attribute;
        private List<FieldInfo>         _objectFields;
        
        private ReorderableList         _listProperty;

        private BotCanon _bot;
        
        private void OnEnable()
        {
            
            //GetObjectFields();
            if(target == null)
                return;
            
            _bot = (BotCanon)target;
            
            _listProperty = new ReorderableList(serializedObject, serializedObject.FindProperty("ActionsList"),true, true, true, true);
        
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
            //serializedObject.Update();

            DrawDefaultInspector();
            //_listProperty.DoLayoutList();
            
            
        }



 #region private methods
     
    
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
 
 
 #endregion       



    }
}
