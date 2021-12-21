    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class OneStageStar : MonoBehaviour
    {       
        void Start()
        {
        //     for(int i =0; i< GameManager.GetInstance.MaxLevel;++i)
        //     {
        //          if (GameManager.GetInstance.StageInfoList[0].Vitory == true)
        //          {
        //              GameObject.Find("UIManager").GetComponent<StageManager>().NextLevel();
        //          }
        //     }
            GameObject.Find("UIManager").GetComponent<StageManager>().NextLevel();
        }
    }
