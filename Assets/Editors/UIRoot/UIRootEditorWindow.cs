using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class UIRootEditorWindow : EditorWindow
{
    //�Ƿ����øð�ť
    [MenuItem("�༭����չ/1:MenuItem", true)]
    static bool VaildateUIRoot()
    {
        return true;
    }

    [MenuItem("�༭����չ/1:MenuItem", false)]
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

        //Buttonִ�з�ʽ
        if (GUILayout.Button("ClickButton"))
        {
            Debug.Log("����˰�ť");
            Close();
        }
    }

}
