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

    private GameObject SelectedObj;

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
        // ** ���� 50%�� ����
        matColor.a = 0.5f;
        SpriteRender.color = matColor;
        Obj.transform.position =  new Vector3(Pos.x, Pos.y, -9.0f);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var ped = new PointerEventData(null); 

        // ** ���콺�� ��ġ�� �޾ƿ´�.
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);

        // ** ĵ������ �ڽĵ��� 0�� ������ ���
        if (results.Count <= 0) 
            return;
        // �̺�Ʈ ó���κ�
        for(int i = 0; i < results.Count;++i)
        {
            if(results[i].gameObject.tag == "Player1")
            {
                SelectedObj = results[i].gameObject;
                Frefab = Resources.Load("Frefabs/B1 Red Sheet_0") as GameObject;
                Obj = Instantiate(Frefab);                
            }
            if (results[i].gameObject.tag == "Player2")
            {
                SelectedObj = results[i].gameObject;
                Frefab = Resources.Load("Frefabs/Bird5_LightYellow") as GameObject;
                Obj = Instantiate(Frefab);
            }
            if (results[i].gameObject.tag == "Player3")
            {
                SelectedObj = results[i].gameObject;
                Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
                Obj = Instantiate(Frefab);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {        
        // ** ���� ī�޶󿡼� ���콺 ��ġ ���
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        RaycastHit2D Hit = Physics2D.Raycast(Pos, Vector2.zero, -9.0f);

        // �ε�����
       
        // ** ��ü�� collider�� ���� ��� �浹�� �� ���
        if (Hit.collider != null)
        {
            if (Hit.transform.tag == "PlayerSpawn")
            {
                // ** ����
                SpriteRenderer SpriteRender = Obj.GetComponent<SpriteRenderer>();
                Color matColor = SpriteRender.color;
                // ���� 1�� ����
                matColor.a = 1.0f;
                SpriteRender.color = matColor;

                // ** ���� ���� ��ġ�� collider�ʿ� ��ġ
                Obj.transform.position = Hit.transform.position;

                // ** collider ����
                Obj.AddComponent<BoxCollider2D>();

                BoxCollider2D Box2D = Obj.GetComponent<BoxCollider2D>();
                // ** Collider�� ũ�� ����
                Box2D.size = new Vector2(5.0f, 4.0f);
                Box2D.isTrigger = true;

                SelectPlayer();
            }
        }        
        else // ** collider�浹�� �ȵǴ� ���
        {
            // ** ������Ʈ �ı�
            Destroy(Obj);
        }        
    }

    private void SelectPlayer()
    {
        int Cost;
        if (SelectedObj.tag == "Player1")
        {
            Cost = 50;
            if (GameObject.Find("Cost").GetComponent<TextCost>().Cost >= Cost)
            {
                GameObject.Find("Cost").GetComponent<TextCost>().Cost -= Cost;
                Obj.AddComponent<producer>();
            }
            else
                Destroy(Obj);
        }
        if (SelectedObj.tag == "Player2")
        {
            Cost = 150;
            if (GameObject.Find("Cost").GetComponent<TextCost>().Cost >= Cost)
            {
                GameObject.Find("Cost").GetComponent<TextCost>().Cost -= Cost;
                Obj.AddComponent<Tanker>();                
            }
            else
                Destroy(Obj);
        }
        if (SelectedObj.tag == "Player3")
        {
            Cost = 100;
            if (GameObject.Find("Cost").GetComponent<TextCost>().Cost >= Cost)
            {
                GameObject.Find("Cost").GetComponent<TextCost>().Cost -= Cost;
                Obj.AddComponent<Attacker>();
            }
            else
                Destroy(Obj);            
        }
    }
}
