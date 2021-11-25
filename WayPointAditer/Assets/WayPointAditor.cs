using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class WayPointAditor : EditorWindow
{
    [MenuItem("Tools/WayPoint Editor")]
    static public void Initialize()
    {
        WayPointAditor Window = GetWindow<WayPointAditor>();
        Window.Show();
    }

    [Tooltip("")]
    public GameObject ParentNode = null;

    private void OnGUI()
    {
        SerializedObject Obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(Obj.FindProperty("ParentNode"));

        if(ParentNode == null)
        {
            EditorGUILayout.HelpBox("root node ����", MessageType.Warning);
        }
        else
        {
            // ** GUILayout.Width(), GUILayout.Height();
            EditorGUILayout.BeginVertical(GUILayout.MinWidth(100),GUILayout.MaxWidth(500));
            if(GUILayout.Button("Create Node"))
            {
                CreateNode();
            }
            EditorGUILayout.EndVertical();
        }

        // ** ���� ���ڵ� ������ �����Ŵ.
        Obj.ApplyModifiedProperties();
    }

    public void CreateNode()
    {
        GameObject Nodeobj = new GameObject("Node " + ParentNode.transform.childCount);
     //   Nodeobj.transform.parent = ParentNode.transform;  �� ����
        Nodeobj.transform.SetParent(ParentNode.transform);


        Nodeobj.AddComponent<GetGizmo>();
        Nodeobj.AddComponent<Node>();
        Nodeobj.AddComponent<BoxCollider>().isTrigger = true;
        Nodeobj.AddComponent<Rigidbody>().useGravity = false;
        Nodeobj.layer = 8;
        Nodeobj.transform.position = new Vector3(
            Random.Range(-5.0f, 5.0f),
            0.0f,
            Random.Range(-5.0f, 5.0f));

        Node node = Nodeobj.GetComponent<Node>();

        // ������ �ҷ��� 1���� Ŀ���Ѵ�.
        if (ParentNode.transform.childCount > 1)
        {
            node.NextNode = ParentNode.transform.GetChild(ParentNode.transform.childCount - 2).GetComponent<Node>();


            GameObject FirstObj = GameObject.Find("Node " + 0);
            Node FirstNode = FirstObj.GetComponent<Node>();
            FirstNode.NextNode = node;  
        }
    }
}
