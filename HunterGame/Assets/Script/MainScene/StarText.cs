using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    private Text Star1;
    private Text Star2;
    private Text Star3;
    void Start()
    {
        Star1 = GameObject.Find("01Text").GetComponent<Text>();
        Star1.text = "��� ���� ���";

        Star2 = GameObject.Find("02Text").GetComponent<Text>();
        Star2.text = "��� �����ϱ�";

        Star3 = GameObject.Find("03Text").GetComponent<Text>();
        Star3.text = "���� �� 6���� ���Ϸ� ��ȯ";
    }

}
