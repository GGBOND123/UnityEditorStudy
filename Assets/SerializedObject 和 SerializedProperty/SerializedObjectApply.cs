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



//���������[CustomEditor(typeof(T))]���ԣ���дOnInspectorGUI������
//CanEditMultipleObjects ��������Ƿ����ͬʱѡ�в�����   
[CustomEditor(typeof(SerializedObjectApply)), CanEditMultipleObjects]
public class SineAnimationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // OnInspectorGUI �Ļ���ʵ���ڻ����κοؼ�֮ǰ����SerializedObject.Update�������κ��û�����֮����� ApplyModifiedProperties��  ���δ����ApplyModifiedProperties���´�base.OnInspectorGUI()�ڻ����Updateˢ������ֵ��
        base.OnInspectorGUI();
        if (GUILayout.Button("Randomize Sine Function", EditorStyles.miniButton))
        {
            //ֱ�Ӷ����л�������в���������Setter��Ĳ������ã�����������Ҫ�� MonoBehaviour.OnValidate��У�����ݡ�
            //Getter����ȡ������л�����ĵ�һ��ֵ
            serializedObject.FindProperty("m_Period").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_Amplitude").floatValue = Random.Range(0f, 10f);
            serializedObject.FindProperty("m_PhaseShift").floatValue = 111;
            //SerializedObject ��Editor ������������ 
            serializedObject.ApplyModifiedProperties();
        }
    }
}