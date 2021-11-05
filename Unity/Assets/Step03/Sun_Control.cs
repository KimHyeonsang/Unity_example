using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Control : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up,0.5f);
        this.transform.Rotate(Vector3.right, 0.3f);
    }
}
