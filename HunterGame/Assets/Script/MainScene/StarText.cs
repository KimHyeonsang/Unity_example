using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    private Text Star1;
    void Start()
    {
        Star1 = GameObject.Find("01Text").GetComponent<Text>();
        Star1.text = "���� ��� ��Ƽ� ������ ���� ���Ѻ��ƿ�";

    }

}
