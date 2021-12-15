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

    //    GameManager.GetInstance.PlayerList.Clear();

        Action();
    }
}
