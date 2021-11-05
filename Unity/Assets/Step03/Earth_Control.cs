using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Control : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, 0.3f);
        
    }
}
