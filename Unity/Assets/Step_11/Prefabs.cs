using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Prefabs : MonoBehaviour
{
    WayPoint Pointprefabs;

    private Vector2 PointA;
    private Vector2 PointB;

    private void Awake()
    {
        Pointprefabs = GameObject.Find("WayPointManager").GetComponent<WayPoint>();
    }

    void Start()
    {
               
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            // ����� Ȯ���ϱ�
            for(int i = 0;i < Pointprefabs.WayPointCount; ++i)
            {
                //List�� ����ִ°��̶� ���ݰ��� ��ġ�� ���� ���
                if(Pointprefabs.WayPointlist[i].transform.position == transform.position)
                {
                    // ����
                         WayPoint.Destroy(Pointprefabs.WayPointlist[i]);
                   // Pointprefabs.distroyboll(i);
                    
                     PointA = new Vector2(transform.position.x - Pointprefabs.Radius.x, transform.position.z + Pointprefabs.Radius.y);
                    PointB = new Vector2(transform.position.x + Pointprefabs.Radius.x, transform.position.z - Pointprefabs.Radius.y);

                    GameObject Obj = Instantiate(Pointprefabs.WayPointPrefab);

                    Obj.AddComponent<Rigidbody>();
                    Obj.AddComponent<BoxCollider>();


                    Obj.transform.position = new Vector3(
                        Random.Range(PointA.x, PointB.x),
                        5.0f,
                        Random.Range(PointA.y, PointB.y));
                    Pointprefabs.WayPointlist.Add(Obj);



                    break;
                }
             }


                          
            
        }
    }
}
