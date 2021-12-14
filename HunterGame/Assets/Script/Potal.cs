using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    // ���� ��ȯ�ϴ� ��Ż �� �ɷ�ġ 
    [SerializeField] private GameObject Zombi;
    private int MaxZombiNumber;
    private int iNumber = 0;
    

    private void Start()
    {
        Zombi = Resources.Load("Frefabs/Zombie") as GameObject;

        MaxZombiNumber = 20;
        //�κ�ũ
        InvokeRepeating("CountSpawnDelay", 10.0f,10.0f);
    }


    public void CountSpawnDelay()
    {        
        if(iNumber < MaxZombiNumber)
        {
            // ** ���� �߰� ����
            GameObject Obj = Instantiate(Zombi);
            int num = Random.Range(1, 4);

            switch(num)
            {
                case 1:
                    Obj.transform.position = new Vector3(transform.position.x,-10.0f,-9.0f);
                    break;
                case 2:
                    Obj.transform.position = new Vector3(transform.position.x, -16.0f,-9.0f);
                    break;
                case 3:
                    Obj.transform.position = new Vector3(transform.position.x, -22.0f,-9.0f);
                    break;
            }
            ++iNumber;
        }
        else
        {
            CancelInvoke("CountSpawnDelay");
            
        }
    }

}
