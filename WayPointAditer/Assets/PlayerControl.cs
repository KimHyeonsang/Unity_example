using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject Obj;
    private float Speed;
    private Vector3 Diretion;
    private int iNumber;
    Node TargetParent;
    GameObject Chilld;
    private void Awake()
    {
        Chilld = GameObject.Find("ParentNode");
        
    }
    void Start()
    {
        iNumber = 0;
        TargetParent = Chilld.transform.GetChild(iNumber).GetComponent<Node>();
        Diretion = (TargetParent.transform.position - transform.position).normalized;
        ++iNumber;
        Speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Diretion * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        TargetParent = Chilld.transform.GetChild(iNumber).GetComponent<Node>();
        if (other.transform.position == TargetParent.NextNode.transform.position)
        {
            Diretion = (TargetParent.transform.position - transform.position).normalized;
            if (iNumber + 1 >= Chilld.transform.childCount)
                iNumber = 0;
            else
                ++iNumber;
        }
    }
}
