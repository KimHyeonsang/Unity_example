using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullectcontrollor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
    
    // ���� �浹�ʿ��� �۾�
//    private void FixedUpdate()
 //   {
//       
//    }
}
