using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySkill : MonoBehaviour
{
    private GameObject Player;
    private GameObject Ground;
    [SerializeField] private GameObject BulletPrefab;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Ground = GameObject.Find("Ground");
    }
   
    public void GetSkill1()
    {
        GameObject Obj = Instantiate(BulletPrefab);

        Obj.transform.position = new Vector3(
            Ground.transform.position.x - Random.Range(-10, 10),
            0.5f,
            Ground.transform.position.z - Random.Range(-10, 10)
            );

    }
}
