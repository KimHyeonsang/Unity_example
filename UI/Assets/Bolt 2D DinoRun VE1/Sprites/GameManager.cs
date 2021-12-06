using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float CameraSpeed;
    public Camera mainCamera;
    [SerializeField] GameObject frefab1;
    [SerializeField] GameObject frefab2;
    [SerializeField] GameObject frefab3;

    private GameObject Obj1;
    private GameObject Obj2;
    private GameObject Obj3;
    private List<GameObject> ObjList = new List<GameObject>();

    public Transform[] Background;
    float LeftPosX = 0.0f;
    float RightPosX = 0.0f;
    float xScreenHalfSize = 0.0f;
    float yScreenHalfSize = 0.0f;

    private Text ScoreNumber;
    private int Score;
    private PlayerControllor player;
    private void Awake()
    {
        frefab1 = Resources.Load("frefabs/Cactus A") as GameObject;
        frefab2 = Resources.Load("frefabs/Cactus B") as GameObject;
        frefab3 = Resources.Load("frefabs/Cactus C") as GameObject;
    }
    private void Start()
    {
        player = GameObject.Find("GameObject").GetComponent<PlayerControllor>();
        ScoreNumber = GameObject.Find("ScoreNumber").GetComponent<Text>();
        Score = 0;
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 5.0f;
        mainCamera.rect = new Rect(0.0f, 0.0f, 16.0f, 9.0f);

        // 게임 화면 x좌표 절반 담기
        yScreenHalfSize = mainCamera.orthographicSize;
        //게임화면 y좌표 절반담기
        xScreenHalfSize = yScreenHalfSize * mainCamera.aspect;
        //배경 끝x좌표
        //   LeftPosX = -(xScreenHalfSize * 2);
        LeftPosX = -(mainCamera.rect.width / mainCamera.rect.height * mainCamera.orthographicSize);
        // 배경 시작x좌표
        RightPosX = mainCamera.rect.width / mainCamera.rect.height * mainCamera.orthographicSize;

        Obj1 = Instantiate(frefab1);
        Obj2 = Instantiate(frefab2);
        Obj3 = Instantiate(frefab3);
        
        Obj1.transform.position = new Vector3(5.0f, 0.0f, -2.0f);
        Obj2.transform.position = new Vector3(20.0f, 0.0f, -2.0f);
        Obj3.transform.position = new Vector3(35.0f, 0.0f, -2.0f);

        ObjList.Add(Obj1);
        ObjList.Add(Obj2);
        ObjList.Add(Obj3);

        CameraSpeed = 10.0f;
    }
    void Update()
    {       

        if(player.bDie == false)
        {
            mainCamera.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
            ScoreNumber.text = Score.ToString();

            Score++;
        }

        // 무한 지형 만들기
        for (int i = 0;i < Background.Length; ++i)
        {
            // ** 배경으로 넣은 x이 메인카메라 왼쪽으로 넘을 경우
            if (Background[i].position.x < (mainCamera.transform.position.x + LeftPosX) - 3)
            {
                Vector3 nextPos = Background[i].position;
                
                // 메인카메라 우측넘어 재생성
                nextPos = new Vector3(mainCamera.transform.position.x + RightPosX + 4   , nextPos.y, nextPos.z);
                
                Background[i].position = nextPos;
            }
        }

        // 무한 장애물 만들기
        for (int i = 0; i < ObjList.Count; ++i)
        {
            // ** 장애물으로 넣은 x이 메인카메라 왼쪽으로 넘을 경우
            if (ObjList[i].transform.position.x < (mainCamera.transform.position.x + LeftPosX) - 3)
            {
                Vector3 nextPos = ObjList[i].transform.position;

                // 메인카메라 우측넘어 재생성
                nextPos = new Vector3(mainCamera.transform.position.x + RightPosX + 25, nextPos.y, nextPos.z);

                ObjList[i].transform.position = nextPos;
            }
        }
    }

    public void RePlay()
    {
        Score = 0;
        
        mainCamera.transform.position = new Vector3(-1.8f, 1.0f, -10.0f);

        // ** 바닥 재조정
        for(int i=0; i< Background.Length; ++i)
        {
            Background[i].transform.position = new Vector3((-13.75f + (i * 5)), -4.45f, -1.0f);
        }
    }
}
