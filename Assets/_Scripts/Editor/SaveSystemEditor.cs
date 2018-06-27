using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveSystem))]
public class SaveSystemEditor : Editor
{

    private void OnEnable()
    {
    
    }

    public override void OnInspectorGUI()
    {
        SaveSystem sys = (SaveSystem)target;
        if (GUILayout.Button("Reset"))
        {
            sys.Reset();
        }
        if (GUILayout.Button("Log Save"))
        {
            sys.Log();
        }
        DrawDefaultInspector();
    }
}