using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] private Vector2 PointA;
    [SerializeField] private Vector2 PointB;


    [SerializeField]private GameObject WayPointPrefab;
    [SerializeField] private int WayPointCount = 0;
    [SerializeField] public List<GameObject> WayPointlist = new List<GameObject>();

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step_11/WayPointPrefabs") as GameObject;

        
    }

    void Start()
    {

        PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        
        for (int i=0;i< WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);

            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<Collider>();


            Obj.transform.position = new Vector3(
                Random.Range(PointA.x, PointB.x),
                5.0f,
                Random.Range(PointA.y, PointB.y));

            WayPointlist.Add(Obj);
        }
       
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ground")
        {
            for (int i = 0; i < WayPointCount; ++i)
            {
                WayPointlist[i].GetComponent<Rigidbody>().useGravity = false;               
            }
        }
    }
    
}
