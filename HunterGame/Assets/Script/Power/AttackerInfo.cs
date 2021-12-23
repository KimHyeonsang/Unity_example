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
    public int HartUp1 = 60;
    public int AttackUp = 10;
    public Sprite Imge;
    public GameObject FailBG;

    private void Start()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level2.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp1.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    private void Update()
    {
        GameObject.Find("LvText").GetComponent<Text>().text = Level2.ToString() + " / " + MaxLevel.ToString();
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp1.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if(GameManager.GetInstance.inGameMoney >= price)
        {
            Hart += HartUp1;
            Attack += AttackUp;
            price *= 5;
            Level2++;
            GameManager.GetInstance.inGameMoney -= price;
        }
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "��ȭ ����� �����մϴ�.";
        }
       
    }
}
