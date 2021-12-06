using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    private float PlayerSpeed;
    private Animator Anime;
    private Rigidbody2D Rig;
    public Camera mainCamera;
    private bool bJump;
    public bool bDie;
    public GameObject ENDUI;
    private void Awake()
    {
     //   ENDUI = GameObject.Find("ButtonUI");
        Anime = transform.GetComponent<Animator>();
        Rig = transform.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        PlayerSpeed = 10.0f;
        bJump = false;
        bDie = false;
    }
    void Update()
    {
        if (bDie == false)
            transform.position += Vector3.right * PlayerSpeed * Time.deltaTime;
        else
        {
            ENDUI.SetActive(true);
        }

        if (transform.position.y < 0.0f)
        {
            bJump = false;
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }

        // ** 이단점프 제외 겸 점프 키
        if (Input.GetKeyDown(KeyCode.Space) && bJump == false)
        {
            bJump = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 6.5f);
         
        }

        Anime.SetBool("Jump", bJump); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bDie = true;
        
        Anime.SetBool("Die", bDie);
    }

    public void RePlay()
    {
        Start();
        transform.position = new Vector3(-7.0f, 0.0f, -2.0f);
        ENDUI.SetActive(false);
        Anime.SetBool("Jump", bJump);
        Anime.SetBool("Die", bDie);
    }
}
