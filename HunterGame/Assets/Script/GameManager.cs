using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{    
    static private GameManager Instance;
    public int Hart;
    public int Attack;
    static public GameManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new GameManager();

            return Instance;
        }
    }
    
   
}
