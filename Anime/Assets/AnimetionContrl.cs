using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionContrl : MonoBehaviour
{

    private Animator Anim;

    private bool Skill;
    private bool Attack;
    private float SkillTime;
    private float CombinationTime;
    private bool Combination;


    private void Awake()
    {
        Anim = transform.GetComponent<Animator>();
    }
    private void Start()
    {
        Skill = false;
        Attack = false;
        Combination = false;
        SkillTime = 5.0f;
        CombinationTime = 0.4f;
    }   
    void Update()
    {
        var Ver = Input.GetAxis("Vertical");

        if(Attack)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !Skill)
            {
                Skill = true;
                StartCoroutine("PlayerRun");
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                    Ver /= 2;
            }


            if (Skill)
                Ver = 2.0f;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Combination = true;
                Anim.SetBool("Combination", Combination);
                StartCoroutine("SetCombination");
            }
        }

        Anim.SetFloat("Speed", Ver);

        
    }

    private void LateUpdate()
    {
        Anim.SetBool("Attack", Attack);
        
    }
    IEnumerator PlayerRun()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            SkillTime -= Time.deltaTime;

            if (SkillTime <= 0)
                break;

        }

        SkillTime = 5.0f;
        Skill = false;
    }

    IEnumerator SetCombination()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            CombinationTime -= Time.deltaTime;

            if(CombinationTime <= 0)
                break;
            if (Input.GetMouseButton(0))
            {
                Anim.SetTrigger("NextCombination");
                CombinationTime = 0.4f;
            }

        }

        Combination = false;
        CombinationTime = 0.4f;
    }
    public void SetAttackMotion()
    {
        Attack = !Attack;
    }
}
