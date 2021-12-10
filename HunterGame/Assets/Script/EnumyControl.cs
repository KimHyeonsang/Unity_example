using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyControl : MonoBehaviour
{
    private float Speed;
   
    private Animator Anime;
    private bool bWalk;
    private bool bAttack;

    public Potal potal;
    void Start()
    {
        Speed = 2.0f;
       
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
   //     Anime.SetBool("Attack", bAttack);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            bAttack = true;
            Anime.SetBool("Attack", bAttack);
            bWalk = false;
            InvokeRepeating("Attack", 2,2);
        }
        else
        {
            bWalk = true;
        }
    }

    private void Attack()
    {
        bAttack = false;
        Anime.SetBool("Attack", bAttack);
        
    }
}
