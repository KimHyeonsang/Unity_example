using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    //  ** ���� ��Ų ������Ʈ ����
    private GameObject RemoveObject;
    private GameObject BulletObj;

    public float ShortDis;
    private bool bShort;

    [Tooltip("������Ÿ��")]
    private float CoolTime;
    [Tooltip("���� ��Ÿ��")]
    private float CurTime;
    void Start()
    {
        bShort = false;
        CoolTime = 3.0f;
        BulletObj = Resources.Load("Frefabs/NomalBullet") as GameObject;
    }
    void Update()
    {
        // Ÿ���̶�� ������Ʈ ��� �˻�
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Target");


        for(int i = 0;i < Target.Length; ++i )
        {
            // ���� y���� ��ġ�� ���� ���
            if(transform.position.y  == Target[i].transform.position.y)
            {
                if (CurTime <= 0)
                {
                    // �����տ��� ����
                    GameObject Obj = Instantiate(BulletObj);
                    // ��ġ ����
                    Obj.transform.position = new Vector3(transform.position.x + 2, transform.position.y - 1, transform.position.z);

                    // Ÿ�� ��ġ ����
                    Obj.GetComponent<NomalBullet>().TargetPosition(Target[i], AttackerInfo.Attack);

                    CurTime = CoolTime;
                }
                else
                {
                    CurTime -= Time.deltaTime;
                }

                // �Ÿ� ����
                float Distance = Vector2.Distance(transform.position, Target[i].transform.position);

                // ���� ª������ ������
                if(bShort == false)
                {
                    ShortDis = Distance;
                    bShort = true;
                }

                // ������ �Ÿ��� ª���ͺ��� ���� ���
                if (Distance < ShortDis)
                {
                    ShortDis = Distance;
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerSpawn")
        {
            GameObject[] Obj = GameObject.FindGameObjectsWithTag("PlayerSpawn");
    
            for (int i = 0; i < Obj.Length; ++i)
            {
                if (Obj[i].transform.position == collision.transform.position)
                {
                    RemoveObject = Obj[i];
                    Obj[i].SetActive(false);
                }
            }
        }
    }       
    public void Hit(int _Dmg)
    {
        // ** ü���� 0 �̻��� ��
        if (AttackerInfo.Hart > 0)
        {
            AttackerInfo.Hart -= _Dmg;
        }

        if (AttackerInfo.Hart <= 0)
        {
            // ** ���� ������Ʈ Ȱ��ȭ
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
