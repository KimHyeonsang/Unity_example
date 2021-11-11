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

    // ** 불렛을 관리하는 리스트
    private List<GameObject> EnableList = new List<GameObject>();
    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    //티슈처럼 뽑아서 쓸려고 
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject> GetDisableList
    {
        get
        {
            return DisableList;
        }
    }

   // ** 생성된 Bullet 셋팅하기위함
   [SerializeField] private GameObject BulletParent = null;

    // ** Bullet의 객체 원형
    [SerializeField] private GameObject BulletPrefab = null;
    // ** 현재 블렛의 갯수
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
                // 안보이게 설정
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
