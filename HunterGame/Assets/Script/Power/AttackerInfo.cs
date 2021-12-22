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
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
        GameObject.Find("Photo").GetComponent<Image>().sprite = Imge;
    }
    private void Update()
    {
        GameObject.Find("DmgText").GetComponent<Text>().text = "���ݷ� :" + Attack.ToString() + " + " + AttackUp.ToString();
        GameObject.Find("HartText").GetComponent<Text>().text = "ü�� :" + Hart.ToString() + " + " + HartUp.ToString();
        GameObject.Find("CostText").GetComponent<Text>().text = "��� :" + price.ToString();
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
            GameObject.Find("FailText").GetComponent<Text>().text = "��ȭ ����� �����մϴ�.";
        }
       
    }
}
