using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    [Tooltip("생명력")]
    public int Hart;
    [Tooltip("공격력")]
    public int Attack;
    [Tooltip("Cost")]
    public int Cost;
    static private PlayerManager Instance;
    static public PlayerManager Getinstace
    {
        get
        {
            if (Instance == null)
                Instance = new PlayerManager();

            return Instance;
        }
    }
}
