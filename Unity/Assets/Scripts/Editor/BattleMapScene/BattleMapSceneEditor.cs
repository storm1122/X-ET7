using System;
using System.Collections.Generic;
using ET;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof (BattleMapScene))]
public class BattleMapSceneEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        BattleMapScene sc = target as BattleMapScene;
        
        if (GUILayout.Button("保存数据"))
        {
            sc.Gen();
        }   
        
    }
}
