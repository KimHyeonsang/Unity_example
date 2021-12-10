using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private static WayPointManager Instance = null;
    private static GameObject Container = null;
    
    public static WayPointManager GetInstance()
    {

        if (Instance == null)
        {
            Container = new GameObject("WayPointManager");
            Instance = new WayPointManager();

            Instance = Container.AddComponent(typeof(WayPointManager)) as WayPointManager;
        }
        return Instance;
    }
    [HideInInspector] public GameObject EnemyPrefabs;

    [Tooltip("Node Prefab")]
    [HideInInspector] public GameObject WayPointList;

    [HideInInspector] public Vector2 PointA;
    [HideInInspector] public Vector2 PointB;

    [HideInInspector] public int NodeNumber;

    [HideInInspector] public Vector3 TargetPoint;

    

    [HideInInspector] public List<GameObject> NodeList;


    private void Awake()
    {
        EnemyPrefabs = Resources.Load("Prefabs/Step_11/Enemy") as GameObject;
        WayPointList = Resources.Load("Prefabs/Step_11/WayPointList") as GameObject;
        NodeList = new List<GameObject>();
    }
    private void Start()
    {
        NodeNumber = 0;

        TargetPoint = new Vector3(0.0f, 0.0f,0.0f);

        for(int i = 0;i < 2; ++i)
        {
            GameObject Obj = Instantiate(WayPointList);

            Obj.transform.position = new Vector3(Random.Range(-20, 20),
                0.0f,
                Random.Range(-20, 20));

        }
    }   
}
