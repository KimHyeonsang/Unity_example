using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject Obj;
    private float Speed;
    private Vector3 Diretion;
    Node Target;
    private void Awake()
    {
        Target = new Node();
    }
    void Start()
    {
        
        Diretion = (Target.transform.position - transform.position).normalized;
        Speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Diretion * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 그다음 좌표 받기
        Diretion = (Target.NextNode.transform.position - transform.position).normalized;

        Target = new Node();
    }
}
