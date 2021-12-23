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
    public Sprite Imge;
    public GameObject FailBG;
    void Start()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :   0";
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }

    private void Update()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :  0";
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if (GameManager.GetInstance.inGameMoney >= price)
        {
            Hart += HartUp;
            GameManager.GetInstance.inGameMoney -= price;
            price *= 5;
            Level++;
        }
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "��ȭ ����� �����մϴ�.";
        }

    }
}
