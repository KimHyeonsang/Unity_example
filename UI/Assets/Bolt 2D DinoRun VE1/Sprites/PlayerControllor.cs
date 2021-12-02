using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    private float PlayerSpeed;
    private Animator Anime;
    private Rigidbody2D Rig;
    private bool bJump;
    private void Awake()
    {
        Anime = transform.GetComponent<Animator>();
        Rig = transform.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        PlayerSpeed = 10.0f;
        bJump = false;
        Rig.gravityScale = 0.0f;
    }
    void Update()
    {
        transform.position += Vector3.right * PlayerSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            bJump = true;
            Rig.gravityScale = 1.0f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 8.0f);
         
        }

        if(transform.position.y < 0.0f)
        {
            bJump = false;
            Rig.gravityScale = 0.0f;
        }

        Anime.SetBool("Jump", bJump); 
    }
}
