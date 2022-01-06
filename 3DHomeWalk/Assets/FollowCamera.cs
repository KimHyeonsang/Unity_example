using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // https://www.mixamo.com/#/
    // ** ���� �ٴ� ��ǥ��
    public GameObject Target;

    // ** ī�޶��� �������� ������ �ð�
    [SerializeField] private float SmoothTime;

    // Ÿ���� ���Ѻ� ī�޶� ��ġ
    [SerializeField] private Vector3 Offset;

    // ** ī�޶��� �ִ� �� ��ġ
    [SerializeField] private Vector3 MaxPoint;

    // ** ī�޶��� �ּ� �� ��ġ
    [SerializeField] private Vector3 MinPoint;

    // ** ī�޶� �ӵ�
 //   private Vector3 Velocity;


    // ** ī�޶� Zoom �Ÿ�
    public float Distance;

    // ** ī�޶� ���۳�Ʈ
    private Camera MainCamera;

    // ** �÷��̾ ���� ī�޶󿡼� �Ⱥ��̰� �ϱ�  ����.
    private LayerMask PlayerMask;

    // ** ī�޶��� ������ �ֱ� ����.
    private bool ShakeCamera;

    // ** ī�޶� ��鸱 �� �ݰ�
    [Range(0.0f,1.0f)]
    private float Radius;
    private void Awake()
    {
        MainCamera = GetComponent<Camera>();

        // ** Ư�� ����� �Ⱥ��̰� �ϱ�
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
        // ** ī�޶� ���� ���� & ����
        if (Input.GetKeyDown(KeyCode.Space))
            ShakeCamera = !ShakeCamera;

        // ** ī�޶� ���� ���μ���
        if (ShakeCamera)
        {
            Vector3 ShakeOffset = new Vector3(
                Random.Range(-0.1f, 0.1f) * Radius,
                 Random.Range(-0.1f, 0.1f) * Radius,
                0.0f);

            MainCamera.transform.position += ShakeOffset;
        }
        // ** ��
        MouseWheel();

        // ** Zoom Distance �� �ּҰ� & �ִ밪 ����
        Distance = Mathf.Clamp(Distance, 0.0f, 1.0f);



        Vector3 Direction = Target.transform.forward;

        Direction.z *= -10;

        transform.position = Direction + Target.transform.position;



        // ** ��������  ( �ִ밪�� �ּҰ����̿��� �����̰���)
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

        // ī�޶� Ÿ���� �ε巴�� �ٶ�
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation((Target.transform.position - transform.position).normalized),
            Time.deltaTime);


       

       if(Input.GetMouseButton(0))
        {
            // eulerAngles �� ���Ͱ�
            Vector3 CurrentRotatae = transform.rotation.eulerAngles;

            CurrentRotatae.y += Input.GetAxis("Mouse X") * 50.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotatae);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                CurrentQuaternion,
                Time.deltaTime * 5.0f * SmoothTime);
        }
       

/*
        // ��ġ
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
