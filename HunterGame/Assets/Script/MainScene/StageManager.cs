using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] LevelUnLock;
    private int Level;

    private void Start()
    {
        if(GameManager.GetInstance.CurLevel < GameManager.GetInstance.MaxLevel)
        {
            GameManager.GetInstance.CurLevel = 0;
        }            

    }

    private void Update()
    {
        for(int i = 0;i < GameManager.GetInstance.MaxLevel;++i)
        {
            if(i < GameManager.GetInstance.CurLevel)
            {
                LevelUnLock[i].SetActive(false);
            }
            else
            {
                LevelUnLock[i].SetActive(true);
            }
        }
    }
    public void NextLevel()
    {
        ++GameManager.GetInstance.CurLevel;
        Debug.Log(GameManager.GetInstance.CurLevel);
    }

}
