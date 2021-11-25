using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPoint))]
public class LineEditer : Editor
{
    private void OnSceneGUI()
    {
        WayPoint t = (WayPoint)target;     

        Handles.color = Color.green;
        // 선 이어주기
        for (int i = 0; i < t.WayPointList.Count -1; ++i)
        {
            // ** DrawLine(Vector3 p1,Vector3 p2);
            Handles.DrawLine(t.WayPointList[i].transform.position, t.WayPointList[i + 1].transform.position);
            
        }
        Handles.DrawLine(t.WayPointList[t.WayPointList.Count -1].transform.position, t.WayPointList[0].transform.position);
    }
}
