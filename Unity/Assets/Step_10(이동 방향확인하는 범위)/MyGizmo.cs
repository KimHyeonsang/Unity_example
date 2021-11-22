using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // DrawSphere(Vector3 center, float radius);
        Gizmos.DrawSphere(transform.position,0.2f);
    }
}
