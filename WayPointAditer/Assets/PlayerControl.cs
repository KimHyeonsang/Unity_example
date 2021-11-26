using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject ParentObj;
    [SerializeField] private Node TargetNode = null;

    private bool Moving = false;
    private void Awake()
    {
        ParentObj = GameObject.Find("ParentNode");
        
    }
    void Start()
    {
        Rigidbody Rigid = transform.GetComponent<Rigidbody>();

        Rigid.useGravity = false;

        CapsuleCollider Coll = transform.GetComponent<CapsuleCollider>();

        Coll.center = new Vector3(0.0f, 1.0f, 0.0f);
        Coll.height = 2.0f;
        Coll.isTrigger = true;

        StartCoroutine("NodeChecking");
    }

    // Update is called once per frame
    void Update()
    {
        if(Moving)
        {
            Vector3 Direction = (TargetNode.transform.position - transform.position).normalized;

            transform.position += Direction * 1.5f * Time.deltaTime;

            transform.LookAt(TargetNode.transform);

            Debug.DrawLine(this.transform.position, TargetNode.transform.position, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TargetNode && other.transform.name == ("Node " + TargetNode.Index))
        {
            TargetNode = TargetNode.NextNode;
        }
    }

    IEnumerator NodeChecking()
    {
        while(true)
        {
            // ** 0.5초 간격으로
            yield return new WaitForSeconds(0.5f);

            // ** root node에node가 있는지 확인한다 (2개이상)
            if(ParentObj.transform.childCount > 1)
            {
                // ** 첫번쨰 노드를 찾는다
                TargetNode = ParentObj.transform.GetChild(0).GetComponent<Node>();

                //*8 움직일 준비가 되었다는것을 알림
                Moving = true;

                //** 이루트를 종료한다.
                break;
            }
        }
    }
}
