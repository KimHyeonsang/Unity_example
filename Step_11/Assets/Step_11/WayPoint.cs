using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] private Vector2 PointA;
    [SerializeField] private Vector2 PointB;


    [SerializeField] public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount = 0;
    [SerializeField] public List<GameObject> WayPointlist = new List<GameObject>();

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step_11/WayPointPrefabs") as GameObject;


    }

    void Start()
    {

        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);


        for (int i = 0; i < WayPointCount; ++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);

            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<BoxCollider>();

            Obj.transform.parent = transform;

            Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x,
                WayPointManager.GetInstance().PointB.x),
                5.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y,
                WayPointManager.GetInstance().PointB.y));

            WayPointlist.Add(Obj);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
