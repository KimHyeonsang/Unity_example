using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InputSystem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private GameObject Frefab;
    private GameObject Obj;
    private List<RaycastResult> raycastResults;
    private GraphicRaycaster gr;

    private void Awake() 
    { 
        gr = GetComponent<GraphicRaycaster>(); 
    }

    private void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(eventData.position);
        SpriteRenderer SpriteRender = Obj.GetComponent<SpriteRenderer>();
        Color matColor = SpriteRender.color;
        // ** 투명도 50%로 설정
        matColor.a = 0.5f;
        SpriteRender.color = matColor;
        Obj.transform.position =  new Vector3(Pos.x, Pos.y, -9.0f);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var ped = new PointerEventData(null); 

        // ** 마우스의 위치를 받아온다.
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);

        // ** 캔버스에 자식들이 0개 이하일 경우
        if (results.Count <= 0) 
            return;
        // 이벤트 처리부분
        for(int i = 0; i < results.Count;++i)
        {
            if(results[i].gameObject.tag == "Player1")
            {
                Frefab = Resources.Load("Frefabs/B1 Red Sheet_0") as GameObject;
                Obj = Instantiate(Frefab);
            }
            if (results[i].gameObject.tag == "Player2")
            {
                Frefab = Resources.Load("Frefabs/Bird5_LightYellow") as GameObject;
                Obj = Instantiate(Frefab);
            }
            if (results[i].gameObject.tag == "Player3")
            {
                Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
                Obj = Instantiate(Frefab);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {        
        // ** 메인 카메라에서 마우스 위치 담기
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        RaycastHit2D Hit = Physics2D.Raycast(Pos, Vector2.zero, -9.0f);
       
        // ** 물체의 collider가 있을 경우 충돌이 될 경우
        if (Hit.collider != null)
        {
            // ** 색상
            SpriteRenderer SpriteRender = Obj.GetComponent<SpriteRenderer>();
            Color matColor = SpriteRender.color;
            // 투명도 1도 조절
            matColor.a = 1.0f;
            SpriteRender.color = matColor;

            // ** 놓은 곳에 위치한 collider쪽에 위치
            Obj.transform.position = Hit.transform.position;
            Obj.AddComponent<BoxCollider2D>();

            BoxCollider2D Box2D = Obj.GetComponent<BoxCollider2D>();
            Box2D.size = new Vector2(5.0f, 4.0f);
            Box2D.isTrigger = true;
        }
        else // ** collider충돌이 안되는 경우
        {
            // ** 오브젝트 파괴
            Destroy(Obj);
        }


        
    }
}
