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
        // ��ȯ ���
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
        UiObj.SpawnUIActive();
    }

    void Update()
    {
        // ** ���������� Ŭ���� �� ��
        if (GameManager.GetInstance.KillCount >= GameManager.GetInstance.MaxZombiNumber)
        {
            FirstImage.sprite = Star;

        }

        // ** �÷��̾��� ����� �� ���� ���
        if (GameManager.GetInstance.bSecondStar == true)
        {
            SecondImage.sprite = Star;
        }

        // ** ������ ���� 6�� ���Ϸ� �����
        if (GameManager.GetInstance.ProducerCount <= 6)
        {
            ThirdImage.sprite = Star;
        }

        GameManager.GetInstance.inGameMoney += 50;
    }

}
