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
    }

    void Update()
    {
        // ** 스테이지를 클리어 할 때
        if (GameManager.GetInstance.KillCount >= GameManager.GetInstance.MaxZombiNumber)
        {
            FirstImage.sprite = Star;

        }

        // ** 플레이어의 목숨이 다 있을 경우
        if (GameManager.GetInstance.bSecondStar == true)
        {
            SecondImage.sprite = Star;
        }

        // ** 생산자 갯수 6개 이하로 만들기
        if (GameManager.GetInstance.ProducerCount <= 6)
        {
            ThirdImage.sprite = Star;
        }

        GameManager.GetInstance.inGameMoney += 50;
    }

}
