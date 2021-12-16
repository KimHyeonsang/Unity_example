using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager
{    
    static private GameManager Instance;

    // ** 플레이어 소환 리스트
    private List<GameObject> PlayerList = new List<GameObject>();
    // ** 적 소환 리스트
    public List<GameObject> EnemyList = new List<GameObject>();

    // ** 소환체 리스트
    public List<GameObject> SpawnList = new List<GameObject>();

    // ** 코인리스트
    public List<GameObject> CoinList = new List<GameObject>();

    public int MaxZombiNumber = 20;
    public int KillCount = 0;
    static public GameManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new GameManager();

            return Instance;
        }
    }

    public List<GameObject> GetPlayerList
    {
        get
        {
            return PlayerList;
        }
    }

    
}
