using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Samplerotetion : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        // ** Vector.up = �������� ��Ÿ���� Vector
        // ** Vector.up�� �������� 0.5f�� �ӵ���ŭ ȸ����Ŵ.
        //   this.transform.Rotate(Vetor3.up,0.5f);


        // ** Vector(x,y,z)�� �������� ȸ��,(x,y,z�� ���� �ۼ���)
        //   this.transform.Rotate(0.0f,Time.deltaTime, 0.0f);


        // ** Space.Self = ������ǥ�� �������� ȸ��
        // ** Space.World = �۷ι� ��ǥ�� �������� ȸ��
        //   this.transform.Rotate(0.0f,Time.deltaTime * 100, 0.0f,Space.Self);
        //  this.transform.Rotate(0.0f, Time.deltaTime * 100, 0.0f, Space.World);

        // ** Key�Է��� �޾� ȸ����Ű�� �ڵ带 �ۼ�

        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 5, 0.0f);
    }
}
