using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int Attack;
    public int Hart;
    public int Cost;
    //  ** 삭제 시킨 오브젝트 저장
    private GameObject RemoveObject;

    void Start()
    {        
        Hart = 300;
        Attack = 10;
        Cost = 15;
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
        // ** 체력이 0 이상일 때
        if (Hart > 0)
        {
            Hart -= _Dmg;
        }
        else
        {
            // ** 지운 오브젝트 활성화
            RemoveObject.SetActive(true);
            Destroy(gameObject);            
        }
    }
}
