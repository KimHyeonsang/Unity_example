using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankerInfo : MonoBehaviour
{
    public static int Level = 1;
    public int MaxLevel = 10;
    public static int Hart = 1000;
    public int price = 200;
    public int HartUp = 100;
    public int pice = 10;
    public Sprite Imge;
    public GameObject FailBG;
    void Start()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "공격력 :   0";
        GameObject.Find("HartText").GetComponent<Text>().text = "체력 :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "비용 :" + price.ToString();
        GameObject.Find("piceText").GetComponent<Text>().text = "조각 :" + GameManager.GetInstance.TankerCount + "/" + pice;
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }

    private void Update()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "공격력 :  0";
        GameObject.Find("HartText").GetComponent<Text>().text = "체력 :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "비용 :" + price.ToString();
        GameObject.Find("piceText").GetComponent<Text>().text = "조각 :" + GameManager.GetInstance.TankerCount + "/" + pice;
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if (GameManager.GetInstance.inGameMoney >= price && GameManager.GetInstance.TankerCount >= pice)
        {
            Hart += HartUp;
            GameManager.GetInstance.inGameMoney -= price;
            GameManager.GetInstance.TankerCount -= pice;
            price *= 5;
            Level++;
            pice = Level * 10;
        }    
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "강화 비용과 조각이 부족합니다.";
        }

    }
}
