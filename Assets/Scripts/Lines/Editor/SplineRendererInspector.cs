using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SplineRenderer))]
public class SplineRendererInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SplineRenderer r = target as SplineRenderer;
        if (GUILayout.Button(new GUIContent("Set up line renderer"))){

            r.Setup();
        }
    }
}
