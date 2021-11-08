using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    // ** �������� ��� ������.
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
   // ������  
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
//[SerializeField] ����ȭ ��� public ó�� ����Ƽ�������� �����ִ�. ����� �� ���� ����.
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


    // ** Ű�Է� ������.

    [SerializeField] private float Speed = 0.0f;
    //  [SerializeField] private GameObject BulletObj;
    public GameObject BulletObj;
    //���⼱�� ����
    private List<GameObject> BulletList = new List<GameObject>();
    // Start�� �ʱ�ȭ awake�� �ٸ����� ���𰡸� �����ö�����.

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
        // ** �ּҰ� -1 ~ �ִ밪 1�� ��ȯ;
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0.0f,
            Ver * Speed * Time.deltaTime);

      

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            // ** Instantiate() ����
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
