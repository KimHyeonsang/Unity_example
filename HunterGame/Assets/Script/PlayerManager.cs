using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    [Tooltip("�����")]
    public int Hart;
    [Tooltip("���ݷ�")]
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
