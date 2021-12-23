using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankerInfo : MonoBehaviour
{
    public static int Level3 = 1;
    public int MaxLevel = 10;
    public static int Hart = 1000;
    public int price3 = 200;
    public int HartUp = 100;
    public Sprite Imge;
    public GameObject FailBG;
    void Start()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level3.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :   0";
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price3.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }

    private void Update()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level3.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :  0";
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price3.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if (GameManager.GetInstance.inGameMoney >= price3)
        {
            Hart += HartUp;
            price3 *= 5;
            Level3++;
            GameManager.GetInstance.inGameMoney -= price3;
        }
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "��ȭ ����� �����մϴ�.";
        }

    }
}
