using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    [SerializeField] private float SmoothTime;

    // 타겟을 지켜볼 카메라 위치
    [SerializeField] private Vector3 Offset;

    private Vector3 Velocity;

    private float ZoomDistance;

    private Camera MainCamera;

    private bool ShakeCamera;

    [Range(0.0f,1.0f)]
    private float Radius;
    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
    }
    void Start()
    {
        SmoothTime = 1.0f;

        Offset = new Vector3(0.0f, 5.0f, -8.0f);

        Velocity = Vector3.zero;

        ZoomDistance = 0.0f;

        ShakeCamera = false;

        Radius = 1.0f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ShakeCamera = !ShakeCamera;

        if(ShakeCamera)
        {
            Vector3 ShakeOffset = new Vector3(
                Random.Range(-0.1f,0.1f) * Radius,
                 Random.Range(-0.1f, 0.1f) * Radius,
                0.0f);

            MainCamera.transform.position += ShakeOffset;
        }



        MouseWheel();

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
       else
        {
            // 바라보기
            transform.rotation = Quaternion.Lerp(
                  transform.rotation,
                  Quaternion.LookRotation((Target.transform.position - transform.position).normalized),
                  Time.deltaTime * 5.0f * SmoothTime);
        }

        // 위치
        transform.position = Vector3.SmoothDamp(
            transform.position,
            Target.transform.position + Offset,
            ref Velocity,
            SmoothTime);
    }

    void MouseWheel()
    {
        float Wheel = Input.GetAxis("Mouse ScrollWheel") * -1;
        ZoomDistance += Wheel * 10.0f;

        if (ZoomDistance < 20.0f)
            ZoomDistance = 20.0f;

        if (ZoomDistance > 60.0f)
            ZoomDistance = 60.0f;

        MainCamera.fieldOfView = Mathf.Lerp(
          MainCamera.fieldOfView, ZoomDistance, Time.deltaTime * 5.0f);
    }
}
