using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // https://www.mixamo.com/#/
    // ** 따라 다닐 목표물
    public GameObject Target;

    // ** 카메라의 움직임을 제어할 시간
    [SerializeField] private float SmoothTime;

    // 타겟을 지켜볼 카메라 위치
    [SerializeField] private Vector3 Offset;

    // ** 카메라의 최대 줌 위치
    [SerializeField] private Vector3 MaxPoint;

    // ** 카메라의 최소 줌 위치
    [SerializeField] private Vector3 MinPoint;

    // ** 카메라 속도
 //   private Vector3 Velocity;


    // ** 카메라 Zoom 거리
    public float Distance;

    // ** 카메라 컴퍼넌트
    private Camera MainCamera;

    // ** 플레이어를 메인 카메라에서 안보이게 하기  위함.
    private LayerMask PlayerMask;

    // ** 카메라의 진동을 주기 위함.
    private bool ShakeCamera;

    // ** 카메라가 흔들릴 때 반경
    [Range(0.0f,1.0f)]
    private float Radius;
    private void Awake()
    {
        MainCamera = GetComponent<Camera>();

        // ** 특정 대상을 안보이게 하기
        /*
        PlayerMask = LayerMask.NameToLayer("Player");
        MainCamera.cullingMask = (-1) - (1 << PlayerMask);
        */
    }
    void Start()
    {
        SmoothTime = 0.5f;

        Offset = new Vector3(0.0f, 5.0f, -8.0f);

        MaxPoint = new Vector3(0.0f, 17.5f, -17.5f);

        MinPoint = new Vector3(0.0f, 1.7f, -1.7f);

        //     Velocity = Vector3.zero;
        Distance = 0.5f;

        ShakeCamera = false;

        Radius = 1.0f;
    }
    void Update()
    {
        // ** 카메라 진동 시작 & 종료
        if (Input.GetKeyDown(KeyCode.Space))
            ShakeCamera = !ShakeCamera;

        // ** 카메라 진동 프로세스
        if (ShakeCamera)
        {
            Vector3 ShakeOffset = new Vector3(
                Random.Range(-0.1f, 0.1f) * Radius,
                 Random.Range(-0.1f, 0.1f) * Radius,
                0.0f);

            MainCamera.transform.position += ShakeOffset;
        }
        // ** 줌
        MouseWheel();

        // ** Zoom Distance 의 최소값 & 최대값 고정
        Distance = Mathf.Clamp(Distance, 0.0f, 1.0f);



        Vector3 Direction = Target.transform.forward;

        Direction.z *= -10;

        transform.position = Direction + Target.transform.position;



        // ** 선형보간  ( 최대값과 최소값사이에서 움직이게함)
       transform.position = Vector3.Lerp(
           Target.transform.position + MaxPoint,
           Target.transform.position + MinPoint,
           Distance);
        /*
        var Hor = Input.GetAxis("Horizontal");
        transform.RotateAround(
            Target.transform.position,
            Vector3.up,
             50.0f * Hor * Time.deltaTime);
*/

        // 카메라가 타겟을 부드럽게 바라봄
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation((Target.transform.position - transform.position).normalized),
            Time.deltaTime);


       

       if(Input.GetMouseButton(0))
        {
            // eulerAngles 는 벡터각
            Vector3 CurrentRotatae = transform.rotation.eulerAngles;

            CurrentRotatae.y += Input.GetAxis("Mouse X") * 50.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotatae);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                CurrentQuaternion,
                Time.deltaTime * 5.0f * SmoothTime);
        }
       

/*
        // 위치
        transform.position = Vector3.SmoothDamp(
            transform.position,
            Target.transform.position + Offset,
            ref Velocity,
            SmoothTime);
*/
    }

    void MouseWheel()
    {
        float Wheel = Input.GetAxis("Mouse ScrollWheel") * -1;
        
        if(Wheel != 0)
        {            
            //Distance += Wheel * 10.0f * Time.deltaTime;
             Distance = Mathf.Lerp(
            Distance,
            Distance - Wheel,
            10.0f * Time.deltaTime);
           
        }

    }
}
