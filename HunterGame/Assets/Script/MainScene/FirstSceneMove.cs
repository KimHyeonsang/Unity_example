using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneMove : MonoBehaviour
{
    public void MoveScene()
    {
        // ** �ڿ� �Ҹ�
        if(GameManager.GetInstance.CurPower >= 15)
        {
            GameManager.GetInstance.CurPower -= 15;
            SceneManager.LoadScene("SampleScene");
        }
            
    }

    public void FirstScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
