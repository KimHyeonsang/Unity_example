using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackerInfo : MonoBehaviour
{
    public static int Level2 = 1;
    public int MaxLevel = 10;
    public static int Hart = 300;
    public static int Attack = 40;
    public int price = 100;
    public int HartUp = 60;
    public int AttackUp = 10;
    public int pice = 10;
    public Sprite Imge;
    public GameObject FailBG;

    private void Start()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level2.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("piceText").GetComponent<Text>().text = "���� :" + GameManager.GetInstance.TankerCount + "/" + pice;
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    private void Update()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level2.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("piceText").GetComponent<Text>().text = "���� :" + GameManager.GetInstance.AttackCount + "/" + pice ;
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if(GameManager.GetInstance.inGameMoney >= price && GameManager.GetInstance.AttackCount >= pice)
        {
            Hart += HartUp;
            Attack += AttackUp;
            GameManager.GetInstance.inGameMoney -= price;
            GameManager.GetInstance.AttackCount -= pice;
            price *= 5;
            Level2++;
            pice = Level2 * 10;
        }
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "��ȭ ���� ������ �����մϴ�.";
        }
       
    }
}
