using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private GameObject Frefab;
   
    private void Awake()
    {
    //    Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
        
    }
    void Start()
    {
        
    }
    void Update()
    {
     //   transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime);
    }

    // ** º“»Ø
    public void PlayerSpowns()
    {
        Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
        GameObject Obj = Instantiate(Frefab);
        Obj.transform.position = new Vector3(0,-10.0f,-9.0f);
                
    }
}
