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
    public int iNumber = 0;
    public int KillCount = 0;

    public int inGameMoney = 0;
    public int MaxPower = 150;
    public int CurPower = 150;
    public int Dia = 0;

    // ** 2번째 클리어 조건
    public bool bSecondStar = true;

    // ** 3번째 클리어 조건
    public int AttackerCount = 0;
    public int TankerCount = 0;
    public int ProducerCount = 0;

    public struct Stage
    {
        public string StageName;
        public bool FirstStar;
        public bool TwoStar;
        public bool TreeStar;
        public bool Vitory;
    }

    public Stage StageOne;
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
