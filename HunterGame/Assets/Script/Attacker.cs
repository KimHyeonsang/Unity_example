using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int Attack;
    public int Hart;
    public GameObject OtherObject;
    public Potal enumy;

    void Start()
    {
        OtherObject = GameObject.Find("JumbiPotal");
        enumy = OtherObject.GetComponent<Potal>();
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
                    Obj[i].SetActive(false);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "Target")
        {

            GameObject[] Obj = GameObject.FindGameObjectsWithTag("Target");

            for (int i = 0; i < Obj.Length; ++i)
            {
                if (Obj[i].transform.position == collision.transform.position)
                {
                    InvokeRepeating("Hit", 5,5);
                }
            }
            
        }
       
    }

    private void Hit()
    {
        if (Hart > 0)
        {
            Hart -= enumy.Dmg;
        }
        else
        {
           
            GameObject[] Obj = GameObject.FindGameObjectsWithTag("PlayerSpawn");

            for (int i = 0; i < Obj.Length; ++i)
            {
                if (Obj[i].transform.position == transform.position)
                {
                    Obj[i].SetActive(true);
                }
            }
            Destroy(gameObject);
            
        }
    }
}
