using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggOpen : MonoBehaviour
{
    private bool Open;
    private int DiaNumber;
    public GameObject TargetButton;
    void Start()
    {
        Open = false;
    }

    void Update()
    {
        if (Open)
        {

        }
    }

    public void RandomEggOpen()
    {
        int RandomNum = Random.Range(0, 10);
        if(GameManager.GetInstance.Dia >= DiaNumber)
        {
            Open = true;
            switch(RandomNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    int RandomMoney = Random.Range(1000, 10000);
                    GameManager.GetInstance.inGameMoney += RandomMoney;
                    break;
                case 7:
                    GameObject RandomObj1 = Resources.Load("Frefabs/ProducerIcion") as GameObject;
                    Instantiate(RandomObj1);
                    break;
                case 8:
                    GameObject RandomObj2 = Resources.Load("Frefabs/AttakerIcoin") as GameObject;
                    Instantiate(RandomObj2);
                    break;
                case 9:
                    GameObject RandomObj3 = Resources.Load("Frefabs/TankerIcoin") as GameObject;
                    Instantiate(RandomObj3);
                    break;

            }
           
        }
    }
    public void OnClick(GameObject _Target)
    {
        TargetButton = _Target;
        switch(TargetButton.name)
        {
            case "OneButton":
                DiaNumber = 200;
                
                break;
            case "TenButton":
                DiaNumber = 2000;
                break;
        }
    }
}
