using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGeneration))]
public class MapGenEditor : Editor
{

    public override void OnInspectorGUI()
    {
        MapGeneration mapGen = (MapGeneration)target;
        if (DrawDefaultInspector())
        {
            mapGen.GenMap();
        }
        if (GUILayout.Button("Generate"))
        {
            mapGen.GenMap();
        }
    }
}
