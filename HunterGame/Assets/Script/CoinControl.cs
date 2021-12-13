using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
     //   if(Input.GetMouseButtonDown(0))
     //   {
            if(Input.mousePosition == transform.position)
            {
                Debug.Log("Coin");
            }
            
     //   }
    }
}
