using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitory : MonoBehaviour
{
    public Image FirstImage;
    public Image SecondImage;
    public Image ThirdImage;
    public Sprite Star;
    void Start()
    {
        // 소환 목록
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
        UiObj.SpawnUIActive();        

   
    //    GameManager.GetInstance.StageInfoList[0].SetStage(true);
        
        GameManager.GetInstance.inGameMoney += 50;

    }

  

}
