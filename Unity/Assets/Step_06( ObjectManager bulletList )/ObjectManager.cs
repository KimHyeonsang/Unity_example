using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance()
    {
       
            if (Instance == null)
                Instance = new ObjectManager();
            return Instance;      

    }

    // ** �ҷ��� �����ϴ� ����Ʈ
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    //Ƽ��ó�� �̾Ƽ� ������ 
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }

   // ** ������ Bullet �����ϱ�����
   [SerializeField] private GameObject BulletParent = null;

    // ** Bullet�� ��ü ����
    [SerializeField] private GameObject BulletPrefab = null;
    // ** ���� ���� ����
    private int BullectCount = 0;

    private void Awake()
    {
      BulletParent = new GameObject("BulletParent");
      
      BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
    }
    private void Start()
    {
        BullectCount = 0;
    }

    /*
    public void Fire()
    {
        
        if(DisableList.Count == 0)
        {
            for(int i = 0; i < 5; ++i)
            {
               
                GameObject Obj =  Instantiate(BulletPrefab);
                // �Ⱥ��̰� ����
                Obj.gameObject.SetActive(false);

                DisableList.Push(Obj);
            }

            GameObject Bullet = DisableList.Pop();
            Bullet.SetActive(true);

            EnableList.Add(Bullet);


        }
    }
    */
}
