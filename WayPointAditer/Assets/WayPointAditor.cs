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
            EditorGUILayout.HelpBox("root node 없음", MessageType.Warning);
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

        // ** 현재 위코드 내용을 적용시킴.
        Obj.ApplyModifiedProperties();
    }

    public void CreateNode()
    {
        GameObject Nodeobj = new GameObject("Node " + ParentNode.transform.childCount);
     //   Nodeobj.transform.parent = ParentNode.transform;  과 동일
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

        // 연결을 할려면 1보단 커야한다.
        if (ParentNode.transform.childCount > 1)
        {
            node.NextNode = ParentNode.transform.GetChild(ParentNode.transform.childCount - 2).GetComponent<Node>();


            GameObject FirstObj = GameObject.Find("Node " + 0);
            Node FirstNode = FirstObj.GetComponent<Node>();
            FirstNode.NextNode = node;  
        }
    }
}
