using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Robot.Attributes
{
	
	[CustomEditor(typeof(Bot), true, isFallback = true)]
	[CanEditMultipleObjects]
    public class FolderAttributeDrawer: Editor
    {
		
		public Dictionary<string, FolderAttributeCache> 	Storage 	{get; } = new Dictionary<string, FolderAttributeCache>();
		public List<SerializedProperty> 					Properties 	{get; } = new List<SerializedProperty>();
		
		private bool 			_initialized = false;

        private FolderAttribute _attribute;
        private GUIStyle        _style;
		private Colors 			_colors;

		private List<FieldInfo> _objectFields;

		private void OnEnable()
		{
			
			_colors = new Colors();
			_colors.col0 = new Color(0.2f, 0.2f, 0.2f, 1f);
			_colors.col1 = new Color(1, 1, 1, 0.1f);
			_colors.col2 = new Color(0.25f, 0.25f, 0.25f, 1f);
			
			
			_objectFields = target.GetType()
				.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
				.ToList();

			Repaint();
		}

		private void OnDisable()
		{
			foreach (var folder in Storage)
			{
				folder.Value.Clear();
			}
		}

		private void Awake()
		{
			var texture_in = Resources.Load<Texture2D>("Textures/IN foldout focus-6510");
			var texture_on = Resources.Load<Texture2D>("Textures/IN foldout focus on-5718");
            var color = Color.white;
            
			_style = new GUIStyle(EditorStyles.foldout);

			_style.overflow = new RectOffset(-10, 0, 3, 0);
			_style.padding = new RectOffset(25, 0, -3, 0);

			_style.active.textColor = color;
			_style.active.background = texture_in;
			_style.onActive.textColor = color;
			_style.onActive.background = texture_on;

			_style.focused.textColor = color;
			_style.focused.background = texture_in;
			_style.onFocused.textColor = color;
			_style.onFocused.background = texture_in;	

        }

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
		
			if (!_initialized)
			{
				var length = _objectFields.Count;
				
				for (var i = 0; i < length; i++)
				{
					var currentAttribute = Attribute
						.GetCustomAttribute(_objectFields[i], typeof(FolderAttribute)) as FolderAttribute;

					
					FolderAttributeCache cache;
					if (currentAttribute == null)
					{
						if (_attribute != null && _attribute.Multiple)
						{
							if (!Storage.TryGetValue(_attribute.Name, out cache))
								Storage.Add(_attribute.Name, new FolderAttributeCache(_attribute, _objectFields[i].Name));
							else
								cache.Types.Add(_objectFields[i].Name);
						}
						continue;
					}

					
					_attribute = currentAttribute;
					if (!Storage.TryGetValue(currentAttribute.Name, out cache))
						Storage.Add(currentAttribute.Name, new FolderAttributeCache(currentAttribute, _objectFields[i].Name));
					else
						cache.Types.Add(_objectFields[i].Name);
					
				}

			
				var property = serializedObject.GetIterator();				
				
				if(property.NextVisible(true))
				{
					do 
					{
						bool haveToFold = false;

						foreach (var folder in Storage)
						{
							if (folder.Value.Types.Contains(property.name))
							{
								haveToFold = true;
								folder.Value.Properties.Add(property.Copy());

								break;
							}
						}

						if (haveToFold == false)
						{
							Properties.Add(property.Copy());
						}
					} while (property.NextVisible(false));
				}
			}
			
			if (Properties.Count == 0)
			{
				DrawDefaultInspector();
				return;
			}

			_initialized = true;

			using (new EditorGUI.DisabledScope("m_Script" == Properties[0].propertyPath))
			{
				EditorGUILayout.PropertyField(Properties[0], true);
			}

			EditorGUILayout.Space();

			
			foreach (var folder in Storage)
			{
				Rect rect;
				
				rect = EditorGUILayout.BeginVertical();

				EditorGUILayout.Space();

				EditorGUI.DrawRect(new Rect(rect.x - 1, rect.y - 1, rect.width + 1, rect.height + 1), _colors.col0);
				EditorGUI.DrawRect(new Rect(rect.x - 1, rect.y - 1, rect.width + 1, rect.height + 1), _colors.col1);

				folder.Value.Expanded = EditorGUILayout
					.Foldout(folder.Value.Expanded, folder.Value.Attribute.Name, true, _style != null ? _style : EditorStyles.foldout);


				EditorGUILayout.EndVertical();

				rect = EditorGUILayout.BeginVertical();

				EditorGUI.DrawRect(new Rect(rect.x - 1, rect.y - 1, rect.width + 1, rect.height + 1), _colors.col2);

				if (folder.Value.Expanded)
				{
					EditorGUILayout.Space();
					{
						for (int i = 0; i < folder.Value.Properties.Count; i++)
						{
							EditorGUI.indentLevel = 1;

							EditorGUILayout
								.PropertyField(folder.Value.Properties[i], new GUIContent(folder.Value.Properties[i].name.FirstLetterToUpperCase()), true);
							if (i == folder.Value.Properties.Count - 1)
								EditorGUILayout.Space();
						}
					}
				}

				EditorGUI.indentLevel = 0;
				EditorGUILayout.EndVertical();
				EditorGUILayout.Space();
			}
		}
    
		public class FolderAttributeCache
		{
			public FolderAttribute 			Attribute 	{get; private set;}
			
			public HashSet<string> 			Types 		{get; } = new HashSet<string>();
			public List<SerializedProperty> Properties 	{get; } = new List<SerializedProperty>();
			
			public bool 					Expanded 	{get; set;} = false;

			public FolderAttributeCache(FolderAttribute attribute, string hashIndex)
			{
				Attribute = attribute;
				Types.Add(hashIndex);

			}
			
			
			public void Clear()
			{	
				Types.Clear();
				Properties.Clear();
				
				Attribute = null;
				Expanded = false;
			}
		}
	
		public struct Colors
		{
			public Color col0;
			public Color col1;
			public Color col2;
		}
	
	}

	public static class Extensions
	{
		public static string FirstLetterToUpperCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
				return string.Empty;

			char[] a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			return new string(a);
		}

		public static IList<Type> GetTypeTree(this Type t)
		{
			var types = new List<Type>();
			while (t.BaseType != null)
			{
				types.Add(t);
				t = t.BaseType;
			}

			return types;
		}
	}

}