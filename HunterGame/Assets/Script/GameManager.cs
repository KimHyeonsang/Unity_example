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


    public int MaxZombiNumber = 20;
    public int iNumber = 0;
    public int KillCount = 0;

    public int inGameMoney = 1000000;
    public int MaxPower = 150;
    public int CurPower = 150;
    public int Dia = 0;

   
    // ** �ִ뽺������
    public int MaxLevel = 4;
    // ** ���� ��������
    public int CurLevel;
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
}
