using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullectcontrollor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 200);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
    */
    // 연산 충돌쪽에서 작업
//    private void FixedUpdate()
 //   {
//       
//    }
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
}
