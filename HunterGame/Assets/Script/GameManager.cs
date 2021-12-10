using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    static private GameManager Instance;
    
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
