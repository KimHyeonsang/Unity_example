using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static int Level;
    public int MaxLevel;
    public GameObject[] LevelUnLock;

    private void Start()
    {
        Level = 1;
        MaxLevel = 4;
    }

    private void Update()
    {
        for(int i = 0;i < MaxLevel;++i)
        {
            if(i < Level)
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
        ++Level;
        Debug.Log(Level);
    }

    public void Resetaa()
    {
        Level = 1;
    }
}
