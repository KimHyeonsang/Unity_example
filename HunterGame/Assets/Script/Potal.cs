using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject Obj = GameObject.Find("Potal02");
        if(other.transform.tag == "Player")
        {
            other.transform.position = new Vector3(Obj.transform.position.x, 0.5f, Obj.transform.position.z);
        }
    }
}
