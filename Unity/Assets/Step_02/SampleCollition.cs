using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("충돌 중------------");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("충돌 종료");
    }





    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌 중------------");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 종료");
    }
}
