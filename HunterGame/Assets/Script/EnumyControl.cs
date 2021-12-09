using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyControl : MonoBehaviour
{
    private float Speed;
    private int Hart;
    private int Attack;
    private Animator Anime;
    private bool bWalk;
    void Start()
    {
        Speed = 2.0f;
        Hart = 150;
        Attack = 50;
        Anime = GetComponent<Animator>();
        transform.Rotate(new Vector3(0, 180, 0));
        bWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        Anime.SetBool("Walk", bWalk);
    }

   
    
}