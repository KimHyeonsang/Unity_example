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

        // ����
        var Direction = (Target.transform.position - transform.position).normalized;

        // ** Quaternion.LookRotation = transform�� rotation���� Quaternion���� ��ȯ

        if (Distance <= 25.0f)
        {
            Agent.SetDestination(Target.transform.position);
        }
        else
        {
            Agent.enabled = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, // ��ü ȸ������ �����
          Quaternion.LookRotation(Direction), // ���� �ٶ󺸴¹���
          Time.deltaTime * 1.0f);

            Agent.enabled = true;
        }

    }
}
