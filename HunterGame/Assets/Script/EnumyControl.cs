using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyControl : MonoBehaviour
{
    private float Speed;
   
    private Animator Anime;
    private bool bWalk;
    private bool bAttack;
    [Tooltip("공격쿨타임")]
    private float CoolTime;
    [Tooltip("현재 쿨타임")]
    private float CurTime;
    public Potal potal;
    void Start()
    {
        Speed = 2.0f;
        CoolTime = 1.6f;
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

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(CurTime <= 0)
        {
            if (collision.transform.tag == "Player")
            {
                bAttack = true;
                bWalk = false;
                // 충돌체의 오브젝트 불러오기
                GameObject Obj = collision.gameObject;
                
                // 오브젝트의 스크립트 불러오기
                PlayerManager.Getinstace.FindPlayer(Obj,50);

            }
            CurTime = CoolTime;
        }
        else
        {
            CurTime -= Time.deltaTime;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            bWalk = true;
            bAttack = false;
        }
    }

}
