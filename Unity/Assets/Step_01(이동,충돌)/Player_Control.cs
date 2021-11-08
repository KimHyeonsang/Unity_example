using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    // ** 물리엔진 사용 움직임.
    /*
    public Rigidbody Rigid;
    // Start is called before the first frame update
    void Start()
    {
        Rigid.AddForce(Vector3.forward * 2000);
    }

    */

    //** 
    /*
   private Rigidbody Rigid;
   // 생성자  
   private void Awake()
   {
       Rigid = this.gameObject.GetComponent<Rigidbody>();
   }
   // Start is called before the first frame update
   void Start()
   {
       Rigid.AddForce(Vector3.forward * 2000);
   }

   */
    /*
     private Rigidbody Rigid;

     private void Awake()
     {
         //   GameObject Player = GameObject.Find("Player");
         //   Rigid = Player.GetComponent<Rigidbody>();

         Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
     }
     // Start is called before the first frame update
     void Start()
     {
         Rigid.AddForce(Vector3.forward * 2000);
     }
     // Update is called once per frame
     */

    /*
//[SerializeField] 직렬화 방식 public 처럼 유니티엔진에서 볼수있다. 제어는 할 수가 없다.
[SerializeField] private Rigidbody Rigid; 


private void Awake()
{

    Rigid = GameObject.Find("Player").GetComponent<Rigidbody>();
}
// Start is called before the first frame update
void Start()
{
    Rigid.AddForce(Vector3.forward * 2000);
}
*/


    // ** 키입력 움직임.

    [SerializeField] private float Speed = 0.0f;
    //  [SerializeField] private GameObject BulletObj;
    public GameObject BulletObj;
    //여기선느 백터
    private List<GameObject> BulletList = new List<GameObject>();
    // Start는 초기화 awake는 다른곳에 무언가를 가져올때쓴다.

    private GameObject BulletParent = null;
    private int BullectCount;
    private void Awake()
    {
        BulletParent = new GameObject("BulletList");
    }

    void Start()
    {
        BullectCount = 0;
    }

    void Update()
    {
        // ** 최소값 -1 ~ 최대값 1을 반환;
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime);

      

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            // ** Instantiate() 복제
            GameObject Bullet = Instantiate<GameObject>(BulletObj);
            Bullet.transform.position = transform.position;
        
            Bullet.GetComponent<Rigidbody>().useGravity = false;

            Bullet.transform.parent = BulletParent.transform;

            Bullet.transform.name = BulletParent.ToString() + BullectCount;

            ++BullectCount;

            BulletList.Add(Bullet);
        }
    }
}
