using UnityEditor;
using UnityEditorInternal;
using Robot;

[CustomEditor(typeof(BotCanon))]
[CanEditMultipleObjects]
public class UtilityEximple : Editor
{
    private ReorderableList list1;
    private ReorderableList list2;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        this.serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Example1", EditorStyles.boldLabel);
        Utility.DoLayoutListWithFoldout(this.list1);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Example2", EditorStyles.boldLabel);
        Utility.DoLayoutListWithFoldout(this.list2);

        this.serializedObject.ApplyModifiedProperties();
    }

    private void OnEnable()
    {
        var property = this.serializedObject.FindProperty("Drinks");

        this.list1 = Utility.CreateAutoLayout(property);
        this.list2 = Utility.CreateAutoLayout(
            property,
            new string[] { "Drink Name", "Cost", "Key Color" },
            new float?[] { 100, 70 });
    }
}