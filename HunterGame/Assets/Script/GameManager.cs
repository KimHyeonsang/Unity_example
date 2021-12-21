using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager
{    
    static private GameManager Instance = null;

    // ** �÷��̾� ��ȯ ����Ʈ
    private List<GameObject> PlayerList = new List<GameObject>();

    // ** �� ��ȯ ����Ʈ
    public List<GameObject> EnemyList = new List<GameObject>();

    // ** ��ȯü ����Ʈ
    public List<GameObject> SpawnList = new List<GameObject>();

    // ** ���θ���Ʈ
    public List<GameObject> CoinList = new List<GameObject>();

    // ** �������� ������ ����
    public List<Stage> StageInfoList = new List<Stage>();

    public int MaxZombiNumber = 20;
    public int iNumber = 0;
    public int KillCount = 0;

    public int inGameMoney = 0;
    public int MaxPower = 150;
    public int CurPower = 150;
    public int Dia = 0;

    // ** 2��° Ŭ���� ����
    public bool bSecondStar = true;

    // ** 3��° Ŭ���� ����
    public int AttackerCount = 0;
    public int TankerCount = 0;
    public int ProducerCount = 0;

    // ** �ִ뽺������
    public int MaxLevel = 4;
    // ** ���� ��������
    public int CurLevel;

    public class Stage
    {
        // ** �������� ��ȣ
        public int StageNumber;
        // ** ù°��
        public bool FirstStar;
        // ** ��°��
        public bool TwoStar;
        // ** ��°��
        public bool TreeStar;
        // ** �¸� ����
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
        // ** �������� 4����
        for(int i=0;i < MaxLevel; ++i)
        {
            StageOne = new Stage(i + 1, false, false, false, false);
            StageInfoList.Add(StageOne);

        }
    }
}
