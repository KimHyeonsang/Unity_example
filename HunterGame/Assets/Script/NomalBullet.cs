using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : MonoBehaviour
{
    private float Speed;
    private int Dmg;
    private GameObject Target;
    private bool life;
    void Start()
    {
        Speed = 10.0f;
        
    }

    void Update()
    {
        life = false;
        GameObject[] Obj = GameObject.FindGameObjectsWithTag("Target");

        for (int i = 0; i < Obj.Length; ++i)
        {
            if (Obj[i].transform.position == Target.transform.position)
            {
                life = true;
            }
        }
        if (life == false)
            Destroy(gameObject);
        else
        {
            Vector3 vec = Target.transform.position - transform.position;
            vec.Normalize();

            transform.Translate(vec * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Target")
        {
            //데미지
            Target.GetComponent<EnumyControl>().Hit(Dmg);
            //총알 삭제
            Destroy(gameObject);
        }
    }

    public void TargetPosition(GameObject _Obj,int _Dmg)
    {
        Target = _Obj;
        Dmg = _Dmg;
    }
}
