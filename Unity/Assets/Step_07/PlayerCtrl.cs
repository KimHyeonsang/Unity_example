using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Vector3 LookDirection;
    private float WhillSpeed = 0;
    [SerializeField] private float Speed = 0.0f;
    private int Count = 0;
    [SerializeField] private GameObject BulletParent = null;
    [SerializeField] private GameObject BulletPrefab = null;

    private bool bJump;
    private float JumpSpeed = 500.0f;
    Rigidbody rid;
    private void Awake()
    {
        BulletParent = new GameObject("BulletParent");
    //    BulletPrefab = Resources.Load("Step_07/bullet") as GameObject;

    }
    void Start()
    {       
        Speed = 5.0f;
        Count = 0;
        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider bulletcollior = BulletPrefab.GetComponent<SphereCollider>();
        bulletcollior.isTrigger = false;

        rid = GetComponent<Rigidbody>();
        bJump = false;
    }

    private void Update()
    {
        // ** 이동
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow))
        {
            // ** 최소값 -1 ~ 최대값 1을 반환;
            float Hor = Input.GetAxisRaw("Horizontal");
            float Ver = Input.GetAxisRaw("Vertical");

            LookDirection = Ver * Vector3.forward + Hor * Vector3.right;

            transform.rotation = Quaternion.LookRotation(LookDirection);

            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SampleObjectManager.GetInstance.GetDisableList.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject Obj = Instantiate(BulletPrefab);
                    Obj.transform.name = Count.ToString();
                    ++Count;
                    BulletPrefab.SetActive(false);
                    SampleObjectManager.GetInstance.GetDisableList.Push(Obj);                    
                }
            }
            GameObject Bullet = SampleObjectManager.GetInstance.GetDisableList.Pop();
            Bullet.transform.position = transform.position;
            Bullet.SetActive(true);

            SampleObjectManager.GetInstance.GetEnableList.Add(Bullet);

        }
        // ** Jump
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            Jump();

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.transform.Find("Plane"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            rid.velocity = Vector3.zero;
            bJump = false;
        }
    }

    private void Jump()
    {
        if (bJump)
            return;

        bJump = true;
        rid.AddForce(Vector3.up * JumpSpeed);
    }
}
