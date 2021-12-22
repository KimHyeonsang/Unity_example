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
       


        //    GameManager.GetInstance.StageInfoList[0].SetStage(true);
        StageManager.Next_Level();
        // 초기화
        UiObj.ReStartScene();
        GameManager.GetInstance.inGameMoney += 50;

    }

  

}
