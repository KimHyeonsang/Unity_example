using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int Attack;
    public int Hart;
    private EnumyControl Enumy;

    void Start()
    {        
        Hart = 300;
        Attack = 10;
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "PlayerSpawn")
        {
            Debug.Log(collision.transform.tag);
            GameObject Obj = GameObject.FindGameObjectWithTag("PlayerSpawn");
            Obj.SetActive(false);
        }
    }
 //   private void OnCollisionStay2D(Collision2D collision)
 //   {
 //       Debug.Log(collision.transform.tag);
 //       if(collision.transform.tag == "Target")
 //       {
 //           if (Hart > 0)
 //           {
 //               Hart -= GameManager.GetInstance.Attack;
 //               Debug.Log(Hart);
 //           }
 //           else
 //               Destroy(this);
 //       }
 //       
 //   }

}
