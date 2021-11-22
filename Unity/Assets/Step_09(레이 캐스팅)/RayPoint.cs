using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject CubePrefab;

    private void Awake()
    {
        // ** 프리팹불러오기
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
             Vector3 origin, 시작점
             Vector3 direction,방향
             float maxDistance, 감지된 대상의 정보
             int layerMask 끝나는 지점           

             */
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject Obj = Instantiate(CubePrefab);
                Obj.transform.position = hit.point;
                //(Vector3 start, Vector3 end, Color color);
                // 벡터의 정규화는 방향을 알고 싶어서
                //       Debug.DrawLine(MainCamera.transform.position,hit.point,Color.red,0.2f);
                //     Debug.DrawRay(MainCamera.transform.position, Input.mousePosition.normalized * 10.0f, Color.red, 0.3f);
                Debug.DrawLine(transform.position, Vector3.forward * 5.0f, Color.red, 0.3f);
                if (hit.transform.tag == "Enemy")
                {

                    Debug.Log("Enemy" + hit.transform.name + "를 찾았습니다.");
                    // 레이캐스트를 쏘아서 그 위치에 물체나 총알 발사
                }
            }


        }
    }
}
