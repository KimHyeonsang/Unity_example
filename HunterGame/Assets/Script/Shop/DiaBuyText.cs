using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaBuyText : MonoBehaviour
{
    public Text DiaText;
    public Text Dia1Text;
      
    void Start()
    {
        Dia1Text = DiaBuy.SeclectText;
        DiaText.text = Dia1Text.text + "�� ���̾Ƹ� ���� �Ͻðڽ��ϱ�?";
    }

    private void Update()
    {
        Dia1Text = DiaBuy.SeclectText;
        DiaText.text = Dia1Text.text + "�� ���̾Ƹ� ���� �Ͻðڽ��ϱ�?";
    }

}
