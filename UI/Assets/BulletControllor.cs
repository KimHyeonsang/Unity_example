using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllor : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    
    void Start()
    {
        //  Destroy(this.transform.gameObject, 2.0f);
        Invoke("DestroyBullet", 2.0f);
    }
    
    public void DestroyBullet()
    {
        GameObject Obj = Instantiate(Prefab);

        Obj.transform.position = transform.position;

        Destroy(this.transform.gameObject);
        Destroy(Obj,1.5f);
    }
}
