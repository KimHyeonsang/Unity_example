using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject CubePrefab;

    private void Awake()
    {
        // ** �����պҷ�����
        CubePrefab = Resources.Load("Prefabs/Step_10/Cubee") as GameObject;
        MainCamera = GameObject.Find("Main Camera");
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask);
            /*
             Vector3 origin, ������
             Vector3 direction,����
             float maxDistance, ������ ����� ����
             int layerMask ������ ����           

             */
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject Obj = Instantiate(CubePrefab);
                Obj.transform.position = hit.point;
                //(Vector3 start, Vector3 end, Color color);
                // ������ ����ȭ�� ������ �˰� �;
                //       Debug.DrawLine(MainCamera.transform.position,hit.point,Color.red,0.2f);
                //     Debug.DrawRay(MainCamera.transform.position, Input.mousePosition.normalized * 10.0f, Color.red, 0.3f);
                Debug.DrawLine(transform.position, Vector3.forward * 5.0f, Color.red, 0.3f);
                if (hit.transform.tag == "Enemy")
                {

                    Debug.Log("Enemy" + hit.transform.name + "�� ã�ҽ��ϴ�.");
                    // ����ĳ��Ʈ�� ��Ƽ� �� ��ġ�� ��ü�� �Ѿ� �߻�
                }
            }


        }
    }
}
