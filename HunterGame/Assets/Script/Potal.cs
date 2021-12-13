using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    // 좀비만 소환하는 포탈 및 능력치 
    [SerializeField] private GameObject Zombi;
    private int MaxZombiNumber;
    private int iNumber = 0;
    public string EnemyName;
    public int Hp;
    public int Dmg;
    public int AtkSpeed;

    private void Start()
    {
        Zombi = Resources.Load("Frefabs/Zombie") as GameObject;

        MaxZombiNumber = 20;
        //인보크
        InvokeRepeating("CountSpawnDelay", 10.0f,10.0f);
    }


    public void CountSpawnDelay()
    {        
        if(iNumber < MaxZombiNumber)
        {
            // ** 몬스터 추가 예정
            GameObject Obj = Instantiate(Zombi);
            SetEnumeyStatus("Zombi", 300, 50, 2);
            int num = Random.Range(1, 4);

            switch(num)
            {
                case 1:
                    Obj.transform.position = new Vector3(transform.position.x,-10.0f,-9.0f);
                    break;
                case 2:
                    Obj.transform.position = new Vector3(transform.position.x, -15.0f,-9.0f);
                    break;
                case 3:
                    Obj.transform.position = new Vector3(transform.position.x, -20.0f,-9.0f);
                    break;
            }
            ++iNumber;
        }
        else
        {
            CancelInvoke("CountSpawnDelay");
            
        }
    }

    private void SetEnumeyStatus(string _enemyName,int _Hp,int _Dmg , int _atkSpeed)
    {
        EnemyName = _enemyName;
        Hp = _Hp;
        Dmg = _Dmg;
        AtkSpeed = _atkSpeed;
    }
}
