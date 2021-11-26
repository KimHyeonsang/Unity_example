using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{
    public Camera MinimapCamera;

    // ** 흔들어야할 바벼변
    [SerializeField] [Range(0.01f, 0.1f)] float ShakeRadius;

    [SerializeField] [Range(0.01f, 0.1f)] float ShakeTime;

    public GameObject Target;

    private float ZoomDistance;

    private void Awake()
    {
        MinimapCamera = GetComponent<Camera>();
    }
    void Start()
    {
        this.transform.position = new Vector3(0.0f, 45.0f, 0.0f);

        // ** 호출시간을 셋팅
        ShakeTime = 0.5f;

        // ** 흔들기 반경을 셋팅.
        ShakeRadius = 0.1f;

        ZoomDistance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            InvokeRepeating("StartShake", 0f, 0.01f);

        if (Input.GetKeyDown(KeyCode.S))
            Invoke("StopShake", 0.0f);

        MouseWheel();

        CameraHorizontal();

        //** 
        MinimapCamera.fieldOfView = Mathf.Lerp(
            MinimapCamera.fieldOfView, ZoomDistance, Time.deltaTime * 4);

        // **  Target의 이동에 따라 이동
        MinimapCamera.transform.position =
            Target.transform.position - Vector3.forward + Vector3.up * 20.0f;
    }

    void MouseWheel()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * -1;

        
        ZoomDistance += (ScrollWheel * 10);

        if (ZoomDistance < 20f)
            ZoomDistance = 20f;

        if (ZoomDistance > 60f)
            ZoomDistance = 60f;
    }

    void CameraHorizontal()
    {
        if(Input.GetMouseButton(1))
        {
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse X") * 5;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            CurrentQuaternion.z = 0;

            
            transform.rotation = Quaternion.Slerp(
                transform.rotation, CurrentQuaternion, 5 * Time.deltaTime);
        }
    }

    void StartShake()
    {
        Vector3 CameraPos = new Vector3(Random.value * ShakeRadius, Random.value * ShakeRadius);

        Vector3 CurrentCameraPos = new Vector3(
            this.transform.position.x + CameraPos.x,
            this.transform.position.y + CameraPos.y,
            this.transform.position.z);

        MinimapCamera.transform.position = CurrentCameraPos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");

        MinimapCamera.transform.position = this.transform.position;
    }
}
