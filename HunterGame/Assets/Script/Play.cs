using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    private Vector3 pos;
    private void OnCollisionEnter(Collision collision)
    {
        pos = transform.position;

        if (collision.transform.tag == "Wall")
        {
            transform.position = pos;
        }
    }


    private void OnCollisionStay(Collision collision)
    {

        if (collision.transform.tag == "Wall")
        {
            transform.position = pos;
        }

    }

}
