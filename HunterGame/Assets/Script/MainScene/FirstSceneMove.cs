using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneMove : MonoBehaviour
{
    public void MoveScene()
    {
        GameManager.GetInstance.CurPower -= 15;


        SceneManager.LoadScene("SampleScene");
    }

    public void FirstScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
