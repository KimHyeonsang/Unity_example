using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyControl : MonoBehaviour
{
    private float Speed;
   
    private Animator Anime;
    private bool bWalk;
    private bool bAttack;
    void Start()
    {
        Speed = 2.0f;
        GameManager.GetInstance.Hart = 150;
        GameManager.GetInstance.Attack = 50;
        Anime = GetComponent<Animator>();
        transform.Rotate(new Vector3(0, 180, 0));
        bWalk = true;
        bAttack = false;
    }

    void Update()
    {
        if(bWalk == true)
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

        Anime.SetBool("Walk", bWalk);
        Anime.SetBool("Attack", bAttack);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            bAttack = true;
            bWalk = false;
        }        
    }

    public int Attacting()
    {
        return GameManager.GetInstance.Attack;
    }
}
