using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager
{    
    static private GameManager Instance = null;

    // ** 플레이어 소환 리스트
    private List<GameObject> PlayerList = new List<GameObject>();

    // ** 적 소환 리스트
    public List<GameObject> EnemyList = new List<GameObject>();

    // ** 소환체 리스트
    public List<GameObject> SpawnList = new List<GameObject>();

    // ** 코인리스트
    public List<GameObject> CoinList = new List<GameObject>();

    // ** 스테이지 정보를 저장
    public List<Stage> StageInfoList = new List<Stage>();

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

    // ** 최대스테이지
    public int MaxLevel = 4;
    // ** 현재 스테이지
    public int CurLevel;

    public class Stage
    {
        // ** 스테이지 번호
        public int StageNumber;
        // ** 첫째별
        public bool FirstStar;
        // ** 둘째별
        public bool TwoStar;
        // ** 셋째별
        public bool TreeStar;
        // ** 승리 유무
        public bool Vitory;

        public Stage(int _StageNumber, bool _FirstStar, bool _TwoStar, bool _TreeStar, bool _Vitory)
        {
            StageNumber = _StageNumber;
            FirstStar = _FirstStar;
            TwoStar = _TwoStar;
            TreeStar = _TreeStar;
            Vitory = _Vitory;
        }

        public void SetStage(bool _FirstStar, bool _TwoStar,bool _TreeStar,bool _Vitory)
        {
            FirstStar = _FirstStar;
            TwoStar = _TwoStar;
            TreeStar = _TreeStar;
            Vitory = _Vitory;
        }
    }

    public Stage StageOne;
    static public GameManager GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new GameManager();
            }

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
    public void StageInfo()
    {
        // ** 스테이지 4까지
        for(int i=0;i < MaxLevel; ++i)
        {
            StageOne = new Stage(i + 1, false, false, false, false);
            StageInfoList.Add(StageOne);

        }
    }
}
