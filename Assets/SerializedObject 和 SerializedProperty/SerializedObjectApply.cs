using UnityEditor;
using UnityEngine;

public class SerializedObjectApply : MonoBehaviour
{
    public Vector3 axis { get { return m_Axis; } set { m_Axis = value; } }
    [SerializeField]
    private Vector3 m_Axis = Vector3.up;

    public float period { get { return m_Period; } set { m_Period = value; } }
    [SerializeField]
    private float m_Period = 1f / Mathf.PI;

    public float amplitude { get { return m_Amplitude; } set { m_Amplitude = value; } }
    [SerializeField]
    private float m_Amplitude = 1f;

    public float phaseShift { get { return m_PhaseShift; } set { m_PhaseShift = Mathf.Clamp01(value); } }
    [SerializeField, Range(0f, 1f)]
    private float m_PhaseShift;

    void Update()
    {
        transform.localPosition = m_Axis * m_Amplitude * Mathf.Sin((Time.time + m_PhaseShift) / m_Period);
    }

    void OnValidate()
    {
        m_PhaseShift = Mathf.Clamp01(m_PhaseShift);
    }
}



//在类上添加[CustomEditor(typeof(T))]属性，重写OnInspectorGUI方法，
//CanEditMultipleObjects 多个物体是否可以同时选中操作。   
[CustomEditor(typeof(SerializedObjectApply)), CanEditMultipleObjects]
public class SineAnimationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // OnInspectorGUI 的基本实现在绘制任何控件之前调用SerializedObject.Update，并在任何用户交互之后调用 ApplyModifiedProperties。  如果未调用ApplyModifiedProperties，下次base.OnInspectorGUI()内会调用Update刷掉赋的值。
        base.OnInspectorGUI();
        if (GUILayout.Button("Randomize Sine Function", EditorStyles.miniButton))
        {
            //直接对序列化对象进行操作会无视Setter里的参数设置，所以我们需要在 MonoBehaviour.OnValidate中校验数据。
            //Getter将读取多个序列化对象的第一个值
            serializedObject.FindProperty("m_Period").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_Amplitude").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_PhaseShift").floatValue = 111;
            //SerializedObject 在Editor 生命周期内中 
            serializedObject.ApplyModifiedProperties();
        }
    }
}