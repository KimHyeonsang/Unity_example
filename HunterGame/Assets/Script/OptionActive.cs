using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionActive : MonoBehaviour
{
    private bool bCheck;
    private bool IsPause;

    private void Update()
    {
        Time.timeScale = 0;
    }
    public void Action()
    {
        if (bCheck == true)
        {
            bCheck = false;
            IsPause = false;
        }
        else
        {
            bCheck = true;

        }
        GameObject Obj = gameObject;
        Obj.SetActive(bCheck);
        if (!IsPause)
        {
            IsPause = true;
            Time.timeScale = 1;
        }
    }

    public void ReStartScene()
    {
        // 초기화 목록  코인 기본가격,현재 좀비 소환 수 초기화,

        Potal Jumbipotal = GameObject.Find("JumbiPotal").GetComponent<Potal>();
        Jumbipotal.iNumber = 0;

        TextCost Cost = GameObject.Find("Cost").GetComponent<TextCost>();
        Cost.Cost = 100;

        for(int i=0;i< GameManager.GetInstance.GetPlayerList.Count; ++i)
        {
            // 플레이어 지우기   
            Destroy(GameManager.GetInstance.GetPlayerList[i]);

        }
        for(int i=0;i < GameManager.GetInstance.EnemyList.Count;++i)
        {
            // 적군 지우기
            Destroy(GameManager.GetInstance.EnemyList[i]);
        }       

        // 플레이어 소환 가능 장소 리셋
        for (int i = 0; i < GameManager.GetInstance.SpawnList.Count; ++i)
        {
            // 돌리기
            GameManager.GetInstance.SpawnList[i].SetActive(true);
        }

        // 필드에 나와있는 코인 삭제
        for (int i = 0; i < GameManager.GetInstance.CoinList.Count; ++i)
        {            
            Destroy(GameManager.GetInstance.CoinList[i]);
        }

        GameManager.GetInstance.EnemyList.Clear();
        GameManager.GetInstance.GetPlayerList.Clear();
        GameManager.GetInstance.CoinList.Clear();
        Action();
    }
}
