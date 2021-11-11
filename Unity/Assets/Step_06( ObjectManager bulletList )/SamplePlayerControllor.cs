using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerControllor : MonoBehaviour
{
    // ** 키입력 움직임.

    [SerializeField] private float Speed = 0.0f;
    private int Count = 0;
    [SerializeField] private GameObject BulletParent = null;
    [SerializeField] private GameObject BulletPrefab = null;

    private void Awake()
    {
        BulletParent = new GameObject("BulletParent");
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        
    }
    void Start()
    {
        Speed = 5.0f;
        Count = 0;
        Rigidbody BulletRigid = BulletPrefab.GetComponent<Rigidbody>();
        BulletRigid.useGravity = false;

        SphereCollider bulletcollior = BulletPrefab.GetComponent<SphereCollider>();
        bulletcollior.isTrigger = false;
    }

    void Update()
    {
        // ** 최소값 -1 ~ 최대값 1을 반환;
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ObjectManager.GetInstance().GetDisableList.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    
                    GameObject Obj = Instantiate(BulletPrefab);
                    Obj.transform.name = Count.ToString();
                    ++Count;
                    BulletPrefab.SetActive(false);
                    ObjectManager.GetInstance().GetDisableList.Push(Obj);
                }
            }
          
            GameObject Bullet = ObjectManager.GetInstance().GetDisableList.Pop();
            Bullet.transform.position = transform.position;
            Bullet.SetActive(true);

            ObjectManager.GetInstance().GetEnableList.Add(Bullet);
            
        }
    }
}
