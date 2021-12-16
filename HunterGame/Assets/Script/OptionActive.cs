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
        // �ʱ�ȭ ���  ���� �⺻����,���� ���� ��ȯ �� �ʱ�ȭ,

        Potal Jumbipotal = GameObject.Find("JumbiPotal").GetComponent<Potal>();
        Jumbipotal.iNumber = 0;

        TextCost Cost = GameObject.Find("Cost").GetComponent<TextCost>();
        Cost.Cost = 100;

        for(int i=0;i< GameManager.GetInstance.GetPlayerList.Count; ++i)
        {
            // �÷��̾� �����   
            Destroy(GameManager.GetInstance.GetPlayerList[i]);

        }
        for(int i=0;i < GameManager.GetInstance.EnemyList.Count;++i)
        {
            // ���� �����
            Destroy(GameManager.GetInstance.EnemyList[i]);
        }       

        // �÷��̾� ��ȯ ���� ��� ����
        for (int i = 0; i < GameManager.GetInstance.SpawnList.Count; ++i)
        {
            // ������
            GameManager.GetInstance.SpawnList[i].SetActive(true);
        }

        // �ʵ忡 �����ִ� ���� ����
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
