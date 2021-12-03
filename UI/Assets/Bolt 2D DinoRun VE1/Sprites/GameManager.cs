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


        Obj1 = Instantiate(frefab1);
        Obj2 = Instantiate(frefab2);
        Obj3 = Instantiate(frefab3);
        for(int i=0;i<5;i++)
        {
            Obj1.transform.position = new Vector3(Random.Range(0.0f, 110.0f), 0.0f, -2.0f);
            Obj2.transform.position = new Vector3(Random.Range(0.0f, 110.0f), 0.0f, -2.0f);
            Obj3.transform.position = new Vector3(Random.Range(0.0f, 110.0f), 0.0f, -2.0f);
        }
        
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


        //    float Hor = Input.GetAxisRaw("Horizontal");
        //    float Ver = Input.GetAxisRaw("Vertical");
        //
        //    mainCamera.transform.position = new Vector3(
        //        mainCamera.rect.width/ mainCamera.rect.height * mainCamera.orthographicSize * Hor,
        //        mainCamera.orthographicSize * Ver,
        //       0.0f);
        

    }

    public void RePlay()
    {
        Score = 0;
        
        mainCamera.transform.position = new Vector3(-1.8f, 1.0f, -10.0f);
    }
}
