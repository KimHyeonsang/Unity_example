using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int Attack;
    public int Hart;
    //  ** ���� ��Ų ������Ʈ ����
    private GameObject RemoveObject;

    void Start()
    {        
        Hart = 300;
        Attack = 10;
    }
    void Update()
    {
        
    }

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
        if (Hart > 0)
        {
            Hart -= _Dmg;
        }

        if (Hart <= 0)
        {
            // ** ���� ������Ʈ Ȱ��ȭ
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
