using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField]public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount = 0;

    [SerializeField] public List<GameObject> WayPointList = new List<GameObject>();

    // ** Enemy가  처음 가야할 번호
    [SerializeField] private Vector3 Diretion;

    [SerializeField] public GameObject EnemyPrefab;

    private float fTime = 5.0f;


    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step_11/WayPointPrefabs") as GameObject;

    }

    void Start()
    {
        StartCoroutine("CreateEnemy");


        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        
        for (int i=0;i< WayPointCount;++i)
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

            WayPointList.Add(Obj);
        }

        int NodeNumber = WayPointManager.GetInstance().NodeNumber;
        
        WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
        
    }

    
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(fTime);

        GameObject Enemy = Instantiate(WayPointManager.GetInstance().EnemyPrefabs);

        Enemy.transform.position = this.transform.position;
    }
}
