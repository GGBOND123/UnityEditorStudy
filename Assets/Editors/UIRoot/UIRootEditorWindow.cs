using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class UIRootEditorWindow : EditorWindow
{
    //是否启用该按钮
    [MenuItem("编辑器扩展/1:MenuItem", true)]
    static bool VaildateUIRoot()
    {
        return true;
    }

    [MenuItem("编辑器扩展/1:MenuItem", false)]
    static void MunuItem()
    {
        UIRootEditorWindow window = GetWindow<UIRootEditorWindow>();
        window.Show();

    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Width", GUILayout.Width(45));
        GUILayout.TextField("66");
        GUILayout.Label("x", GUILayout.Width(60));
        GUILayout.Label("Height", GUILayout.Width(50));
        GUILayout.TextField("66");
        GUILayout.EndHorizontal();

        //Button执行方式
        if (GUILayout.Button("ClickButton"))
        {
            Debug.Log("点击了按钮");
            Close();
        }
    }

}
