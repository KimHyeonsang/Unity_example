using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ViewAngle))]
public class ViewAngleEditor : Editor
{
    private void OnSceneGUI()
    {

        ViewAngle t = (ViewAngle)target;

        // DrawWireArc(Vector3 center, Vector3 normal, Vector3 from, float angle, float radius);
        //������ �׸���
        Handles.DrawWireArc(
            t.transform.position, Vector3.up, Vector3.forward, 360.0f, t.Radius );


        // ** �����þ߰� �ִ�ġ
        Vector3 LeftViewAngle = t.LocalViewAngle(-t.Angle / 2.0f);
        // ** ���� �þ߰� �ִ�ġ
        Vector3 RightViewAngle = t.LocalViewAngle(t.Angle / 2.0f);

        Handles.DrawLine(t.transform.position, t.transform.position + LeftViewAngle * t.Radius);
        Handles.DrawLine(t.transform.position, t.transform.position + RightViewAngle * t.Radius);

        Handles.color = Color.green;
        // �� �̾��ֱ�
        for (int i=0;i<t.TargetList.Count;++i)
        {
            // ** DrawLine(Vector3 p1,Vector3 p2);
            Handles.DrawLine(t.transform.position, t.TargetList[i].position);

        }
    }
}
