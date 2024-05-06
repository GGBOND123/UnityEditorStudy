using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class SerializedObjectAndSerializedProperty 
{
    [MenuItem("Edit/Reset Selected Objects Position (No Undo)")]
    static void ResetPosition()
    {
        // this action will not be undoable
        foreach (var go in Selection.gameObjects)
            go.transform.localPosition = Vector3.zero;
    }

    [MenuItem("Edit/Reset Selected Objects Position")]
    static void ResetPositionWithUndo()
    {

        var transforms = Selection.gameObjects.Select(go => go.transform).ToArray();
        var so = new SerializedObject(transforms);

        //获取私有属性的名称方式: you can Shift+Right Click on property names in the Inspector to see their paths
        so.FindProperty("m_LocalPosition").vector3Value = Vector3.zero;
        so.ApplyModifiedProperties();


        //数据流中通过 SerializedProperty 对序列化的数据进行更改，通过 SerializedObject.ApplyModifiedProperties 方法来应用。
        //如果多帧持有了序列化的引用，在你从这个引用读取数据时，你必须手动调用SerializedObject.Update刷新后再读。
    }
}
