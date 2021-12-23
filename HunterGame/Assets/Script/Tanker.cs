using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanker : MonoBehaviour
{
    //  ** ���� ��Ų ������Ʈ ����
    public GameObject RemoveObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerSpawn")
        {
            GameObject[] Obj = GameObject.FindGameObjectsWithTag("PlayerSpawn");

            for (int i = 0; i < Obj.Length; ++i)
            {
                if (Obj[i].transform.position == collision.transform.position)
                {
                    RemoveObject = Obj[i];
                    Obj[i].SetActive(false);
                }
            }
        }
    }

    public void Hit(int _Dmg)
    {
        // ** ü���� 0 �̻��� ��
        if (TankerInfo.Hart > 0)
        {
            TankerInfo.Hart -= _Dmg;
        }

        if (TankerInfo.Hart <= 0)
        {
            // ** ���� ������Ʈ Ȱ��ȭ
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }

    }
}
