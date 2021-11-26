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

        Node CurrentNode = Nodeobj.AddComponent<Node>();

        CurrentNode.Index = ParentNode.transform.childCount - 1;


        while (true)
        {
            Nodeobj.transform.position = new Vector3(
                Random.Range(-25.0f, 25.0f), 0.0f, Random.Range(-25.0f, 25.0f));
            float Distance = 1000.0f;

            if(ParentNode.transform.childCount > 1)
            {
                Node PreviousNode = ParentNode.transform.GetChild(
                    ParentNode.transform.childCount - 2).GetComponent<Node>();

                PreviousNode.NextNode = ParentNode.transform.GetChild(
                    ParentNode.transform.childCount - 1).GetComponent<Node>();

                CurrentNode.NextNode = ParentNode.transform.GetChild(0).GetComponent<Node>();

                Distance = Vector3.Distance(
                    PreviousNode.transform.position, CurrentNode.transform.position);
            }
            if (Distance > 1.5f)
                break;
        }
    }

   

}
