using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Samplerotetion : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        // ** Vector.up = 기준축을 나타내는 Vector
        // ** Vector.up을 기준으로 0.5f의 속도만큼 회전시킴.
        //   this.transform.Rotate(Vetor3.up,0.5f);


        // ** Vector(x,y,z)를 기준으로 회전,(x,y,z를 직접 작성함)
        //   this.transform.Rotate(0.0f,Time.deltaTime, 0.0f);


        // ** Space.Self = 로컬좌표를 기준으로 회전
        // ** Space.World = 글로벌 좌표를 기준으로 회전
        //   this.transform.Rotate(0.0f,Time.deltaTime * 100, 0.0f,Space.Self);
        //  this.transform.Rotate(0.0f, Time.deltaTime * 100, 0.0f, Space.World);

        // ** Key입력을 받아 회전시키는 코드를 작성

        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 5, 0.0f);
    }
}
