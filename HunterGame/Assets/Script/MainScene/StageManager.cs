using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] LevelUnLock;
    private int Level;

    private void Start()
    {
        if(GameManager.GetInstance.StageInfoList.Count < GameManager.GetInstance.MaxLevel)
        {
            GameManager.GetInstance.StageInfo();
            Level = GameManager.GetInstance.CurLevel = 0;
        }            

    }

    private void Update()
    {
        for(int i = 0;i < GameManager.GetInstance.MaxLevel;++i)
        {
            if(i < GameManager.GetInstance.StageInfoList[Level].StageNumber)
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
        Level = GameManager.GetInstance.CurLevel;
        Debug.Log(Level);
    }

}
