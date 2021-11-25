using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 Diretion;
    private float Speed = 0.0f;

    private bool Moving = false;

    private float fTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        fTime = 10.0f;
        Diretion = GetDirection();
   //     Debug.Log(Diretion);
        Speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Moving);
        if (Moving)
        {
            transform.Translate(Diretion * Speed * Time.deltaTime);

            transform.LookAt(Diretion);
        }
        else
        {
            //       fTime = 10.0f;
            //       StartCoroutine("Behaviour");
            Diretion = GetDirection();

            Debug.Log(Diretion);
        }
    }

    Vector3 GetDirection()
    {
        Moving = true;

        Vector3 Node = WayPointManager.GetInstance().TargetPoint;

        Debug.Log(Node);

        Vector3 Result = (Node - transform.position);
     //   Debug.Log(Result);
        Result.y = 0.0f;
        return Result.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Node")
        {
            int NodeNumber = WayPointManager.GetInstance().NodeNumber;
           
            ++NodeNumber;
            Moving = false;

            if(NodeNumber > 5)
            {
                NodeNumber = 0;
            }
            WayPointManager.GetInstance().NodeNumber = NodeNumber;
           
        }
    }
 //   IEnumerator Behaviour()
 //   {
 //       yield return new WaitForSeconds(fTime);
 //
 //       
 //       Diretion = GetDirection();
 //   }
}
