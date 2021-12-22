using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackerInfo : MonoBehaviour
{
    public int Hart = 300;
    public int Attack = 40;
    public int price = 100;
    public int HartUp = 100;
    public int AttackUp = 10;
    public Sprite Imge;
    public GameObject FailBG;

    private void Start()
    {
        GameObject.Find("DmgText").GetComponent<Text>().text = "공격력 :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "체력 :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "비용 :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    private void Update()
    {
        GameObject.Find("DmgText").GetComponent<Text>().text = "공격력 :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "체력 :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "비용 :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    public void PowerUp()
    {
        if(GameManager.GetInstance.inGameMoney >= price)
        {
            Hart += HartUp;
            Attack += AttackUp;
            price *= 5;
        }
        else
        {
            FailBG.SetActive(true);
            GameObject.Find("FailText").GetComponent<Text>().text = "강화 비용이 부족합니다.";
        }
       
    }
}
