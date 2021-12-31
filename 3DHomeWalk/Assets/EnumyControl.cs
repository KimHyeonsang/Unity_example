using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnumyControl : MonoBehaviour
{
    private GameObject Target;

    private NavMeshAgent Agent;
    private Transform sdsd;

    private void Awake()
    {
        Target = GameObject.Find("Player");
        Agent = GetComponent<NavMeshAgent>();

        sdsd = transform;
    }
    void Update()
    {
        var Distance = Vector3.Distance(transform.position, Target.transform.position);

        // 방향
        var Direction = (Target.transform.position - transform.position).normalized;

        // ** Quaternion.LookRotation = transform의 rotation값을 Quaternion으로 변환

        if (Distance <= 25.0f)
        {
            Agent.SetDestination(Target.transform.position);
        }
        else
        {
            Agent.enabled = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, // 자체 회전으로 사용중
          Quaternion.LookRotation(Direction), // 내가 바라보는방향
          Time.deltaTime * 1.0f);

            Agent.enabled = true;
        }

    }
}
