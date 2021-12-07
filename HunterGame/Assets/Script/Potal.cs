using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    [SerializeField] private GameObject Zombi;
    private int MaxZombiNumber;
    private int iTime = 5;
    private int iNumber = 0;
    private void Start()
    {
        Zombi = Resources.Load("Frefabs/Zombie") as GameObject;

        // ** 좀비 최대 소환수 
        MaxZombiNumber = 20;

        //인보크
        InvokeRepeating("CountSpawnDelay", 5.0f,5.0f);
    }


    public void CountSpawnDelay()
    {        
        if(iNumber < MaxZombiNumber)
        {
            GameObject Obj = Instantiate(Zombi);

            int num = Random.Range(1, 4);

            switch(num)
            {
                case 1:
                    Obj.transform.position = new Vector3(transform.position.x,-2.0f,7.0f);
                    break;
                case 2:
                    Obj.transform.position = new Vector3(transform.position.x, -9.0f, 6.0f);
                    break;
                case 3:
                    Obj.transform.position = new Vector3(transform.position.x, -16.0f, 5.0f);
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
