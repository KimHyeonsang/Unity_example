using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 Direction;
    Animator anim;
    bool bJump;
    bool bOneJump;
    void Start()
    {
        bJump = false;
        bOneJump = false;
        anim = transform.GetComponent<Animator>();
    }

   
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Hit = 0.0f;
        bJump = false;
       
        if (Hor != 0)
        {
            if(Hor < 0)
            {
                Direction = transform.localScale;

                Direction.x = -Mathf.Abs(Direction.x);

                transform.localScale = Direction;
            }
            else
            {
                Direction = transform.localScale;

                Direction.x = Mathf.Abs(Direction.x);

                transform.localScale = Direction;
            }

            
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            Hit = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !bOneJump)
        {
            bJump = true;
            bOneJump = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5.0f);
        }


        anim.SetFloat("Hit", Hit);
        anim.SetBool("Jump", bJump);
        transform.Translate(new Vector3(Hor * 5.0f * Time.deltaTime,0.0f,0.0f));
        anim.SetFloat("Hor", Hor);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(bOneJump)
            bOneJump = false;
    }
}
