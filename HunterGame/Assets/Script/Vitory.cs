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
    private bool OneCheck;
    private bool TwoCheck;
    private bool TreeCheck;
    void Start()
    {
        // ��ȯ ���
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
        UiObj.SpawnUIActive();

        
        // ** ���������� Ŭ���� �� ��
        if (GameManager.GetInstance.KillCount >= GameManager.GetInstance.MaxZombiNumber)
        {
            FirstImage.sprite = Star;
            OneCheck = true;


        }

        // ** �÷��̾��� ����� �� ���� ���
        if (GameManager.GetInstance.bSecondStar == true)
        {
            SecondImage.sprite = Star;
            TwoCheck = true;
        }

        // ** ������ ���� 6�� ���Ϸ� �����
        if (GameManager.GetInstance.ProducerCount <= 6)
        {
            ThirdImage.sprite = Star;
            TreeCheck = true;
        }
        GameManager.GetInstance.StageInfoList[0].SetStage(OneCheck, TwoCheck, TreeCheck, true);
        Debug.Log(GameManager.GetInstance.StageInfoList[0].FirstStar);
        Debug.Log(GameManager.GetInstance.StageInfoList[0].TwoStar);
        Debug.Log(GameManager.GetInstance.StageInfoList[0].TreeStar);
        Debug.Log(GameManager.GetInstance.StageInfoList[0].Vitory);
        GameManager.GetInstance.inGameMoney += 50;

    }

  

}
