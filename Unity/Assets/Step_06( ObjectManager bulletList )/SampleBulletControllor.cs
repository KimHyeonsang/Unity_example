using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBulletControllor : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000);
    }

    // ** SetActive로 끈걸 다시 킬때 적용
    private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            ObjectManager.GetInstance().GetEnableList.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            ObjectManager.GetInstance().GetDisableList.Push(this.gameObject);
        }
    }
 
}
