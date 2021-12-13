using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class producer : MonoBehaviour
{
    public int Hart;
    private GameObject RemoveObject;

    [SerializeField] private GameObject Coin;
    [Tooltip("������Ÿ��")]
    private float CoolTime;
    [Tooltip("���� ��Ÿ��")]
    private float CurTime;

   
    void Start()
    {
        Hart = 200;
       
        CoolTime = Random.Range(5,11);
        Coin = Resources.Load("Frefabs/Coin") as GameObject;
        CurTime = CoolTime;
    }

    void Update()
    {
        // 5~10�� ���̷� ������ ����
        if (CurTime <= 0)
        {
            GameObject CoinObj = Instantiate(Coin);

            CoinObj.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            CoolTime = Random.Range(5, 8);
            CurTime = CoolTime;
        }
        else
        {
            CurTime -= Time.deltaTime;
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
        if (Hart > 0)
        {
            Hart -= _Dmg;
        }
        
        if(Hart <= 0)
        {
            // ** ���� ������Ʈ Ȱ��ȭ
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
