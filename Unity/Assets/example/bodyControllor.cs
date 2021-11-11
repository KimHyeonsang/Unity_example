using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyControllor : MonoBehaviour
{
    [SerializeField] private float Speed = 0;
    private Vector3 LookDirection;
    private float WhillSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 5;
        WhillSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow))
        {
            // ** 최소값 -1 ~ 최대값 1을 반환;
            float Hor = Input.GetAxisRaw("Horizontal");
            float Ver = Input.GetAxisRaw("Vertical");

            LookDirection = Ver * Vector3.forward + Hor * Vector3.right;

            transform.rotation = Quaternion.LookRotation(LookDirection);

            transform.Translate(Vector3.forward * Speed * Time.deltaTime);           
        }

        // ** 포움직임
        if(gameObject.transform.Find("Angle"))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 aaa = gameObject.transform.Find("Angle").transform.eulerAngles;
                Debug.Log(Mathf.Abs(aaa.x));
                //x축 움직임 위로 최대 -90도 까지
                if ( aaa.x < 5.0f || aaa.x > 275.0f)
                {
                    gameObject.transform.Find("Angle").transform.Rotate(-20 * Time.deltaTime, 0.0f, 0.0f);
                    Debug.Log(Mathf.Max(-90.0f, aaa.x));
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                //x축 움직임 위로 최대 90도 까지
                if (gameObject.transform.Find("Angle").transform.rotation.x < 0)
                    gameObject.transform.Find("Angle").transform.Rotate(20 * Time.deltaTime, 0.0f, 0.0f);
            }
        }

        // ** 포 쏘기
        if (gameObject.transform.Find("PoSin"))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
    }
}
