using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSingletonTest : MonoBehaviour
{

    private void Awake()
    {
        // ** Singleton 3
        Singleton.GetInstance();
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            // ** Singleton 1
            //   Singleton.GetInstance().Output();

            // ** Singleton 2
         //   Singleton.GetInstance.Output();
        }
    }
}
