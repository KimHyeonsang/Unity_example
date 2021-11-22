using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointline : MonoBehaviour
{
    [SerializeField] private GameObject Prefabs;
    [SerializeField] private int Count;

    //���� ������ ������ ����Ʈ
    private Vector2 PointA;
    private Vector2 PointB;

    // ������ ���� ����Ʈ ��
    [SerializeField] private Vector2 Radius;
    [SerializeField] private List<GameObject> WayPointlist = new List<GameObject>();

    private void Awake()
    {
        Prefabs = Resources.Load("Prefabs/Step_11/WayPointPrefabs") as GameObject;

    }
    void Start()
    {
        // ��ǥ�� ��´�
        PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        // ������ ��Ÿ����.
        for (int i=0;i<Count;++i)
        {
            GameObject Obj = Instantiate(Prefabs);

            Obj.transform.position = new Vector3(
                Random.Range(PointA.x, PointB.x),
                5.0f,
                Random.Range(PointA.y, PointB.y));



            GameObject target = Obj;

            // �տ� �ִ°� �ٶ󺸴¹���  ���� ������ ���Ƽ� ���ʹ� �����ϴ�.
            Vector3 TargetDirection = (target.transform.position - transform.position).normalized;

            // �ڱ��ڽ� ���� Ÿ�ٰŸ������� ���� �־��������� ���� ���



            // �Ÿ�
            float TargetDistance = Vector3.Distance(transform.position, target.transform.position);

            WayPointlist.Add(target);


        }

        
            
        
    }

    
    void Update()
    {
        
    }
}
