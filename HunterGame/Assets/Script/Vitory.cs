using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitory : MonoBehaviour
{    
    void Start()
    {
        // ��ȯ ���
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
       
        StageManager.Next_Level();
        // �ʱ�ȭ
        UiObj.ReStartScene();
        GameManager.GetInstance.inGameMoney += 50;

    }

}
