using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointline : MonoBehaviour
{
    [SerializeField] private GameObject Prefabs;
    [SerializeField] private int Count;

    //선을 연결할 마지막 포인트
    private Vector2 PointA;
    private Vector2 PointB;

    // 연결한 선의 포인트 점
    [SerializeField] private Vector2 Radius;
    [SerializeField] private List<GameObject> WayPointlist = new List<GameObject>();

    private void Awake()
    {
        Prefabs = Resources.Load("Prefabs/Step_11/WayPointPrefabs") as GameObject;

    }
    void Start()
    {
        // 좌표를 잡는다
        PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        // 원형을 나타낸다.
        for (int i=0;i<Count;++i)
        {
            GameObject Obj = Instantiate(Prefabs);

            Obj.transform.position = new Vector3(
                Random.Range(PointA.x, PointB.x),
                5.0f,
                Random.Range(PointA.y, PointB.y));



            GameObject target = Obj;

            // 앞에 있는게 바라보는방향  가는 방향은 같아서 벡터는 동일하다.
            Vector3 TargetDirection = (target.transform.position - transform.position).normalized;

            // 자기자신 부터 타겟거리까지가 지금 주어진값보다 낮을 경우



            // 거리
            float TargetDistance = Vector3.Distance(transform.position, target.transform.position);

            WayPointlist.Add(target);


        }

        
            
        
    }

    
    void Update()
    {
        
    }
}
