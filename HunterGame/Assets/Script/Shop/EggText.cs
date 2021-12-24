using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggText : MonoBehaviour
{
    public Text EggOpenText;
    private GameObject TargetButton;
    void Start()
    {
        switch (TargetButton.name)
        {
            case "OneButton":
                EggOpenText.text = "200���̾Ʒ� �����Ͻðڽ��ϱ�?";
                break;
            case "TenButton":
                EggOpenText.text = "2000���̾Ʒ� �����Ͻðڽ��ϱ�?";
                break;
        }
    }

    void Update()
    {
        switch (TargetButton.name)
        {
            case "OneButton":
                EggOpenText.text = "200���̾Ʒ� �����Ͻðڽ��ϱ�?";
                break;
            case "TenButton":
                EggOpenText.text = "2000���̾Ʒ� �����Ͻðڽ��ϱ�?";
                break;
        }
    }

    public void OnClick(GameObject _Target)
    {
        TargetButton = _Target;
    }
}
