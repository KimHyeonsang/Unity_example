using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    // ���� ��ȯ�ϴ� ��Ż �� �ɷ�ġ 
    [SerializeField] private GameObject Zombi;   
    public int iNumber = 0;
    

    private void Start()
    {
        Zombi = Resources.Load("Frefabs/Zombie") as GameObject;

       
        //�κ�ũ
        InvokeRepeating("CountSpawnDelay", 10.0f,10.0f);
    }


    public void CountSpawnDelay()
    {        
        if(iNumber < GameManager.GetInstance.MaxZombiNumber)
        {
            // ** ���� �߰� ����
            GameObject Obj = Instantiate(Zombi);
            int num = Random.Range(1, 4);

            switch(num)
            {
                case 1:
                    Obj.transform.position = new Vector3(transform.position.x,-10.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
                    break;
                case 2:
                    Obj.transform.position = new Vector3(transform.position.x, -16.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
                    break;
                case 3:
                    Obj.transform.position = new Vector3(transform.position.x, -22.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
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
