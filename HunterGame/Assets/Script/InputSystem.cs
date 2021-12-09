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
    private void Update()
    {
      // if (Input.GetMouseButtonDown(0))
      // {
      //     if (!EventSystem.current.IsPointerOverGameObject())
      //     {
      //         Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //
      //         RaycastHit2D Hit = Physics2D.Raycast(Pos,Vector2.zero,0f);
      //
      //         Debug.Log("Object");
      //         if (Hit.collider != null)
      //         {
      //            // Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
      //            // GameObject Obj = Instantiate(Frefab);
      //            // Obj.transform.position = Hit.transform.position;
      //         }
      //     }
      //     else
      //     {
      //         Debug.Log("UI");
      //         Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //
      //         RaycastHit2D Hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);
      //         
      //     //    if (Hit.transform.tag == "Player3")
      //     //    {
      //     //        Debug.Log("5");
      //     //    }
      //         
      //     }
      // }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SpriteRenderer SpriteRender = Obj.GetComponent<SpriteRenderer>();
        Color matColor = SpriteRender.color;
        matColor.a = 0.5f;
        SpriteRender.color = matColor;
        Obj.transform.position =  new Vector3(Pos.x, Pos.y, -20.0f);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
    //    Frefab = Resources.Load("Frefabs/B1 Red Sheet_0") as GameObject;
    //    Frefab = Resources.Load("Frefabs/Bird5_LightYellow") as GameObject;
        Obj = Instantiate(Frefab);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D Hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

        if (Hit.collider != null)
        {
            SpriteRenderer SpriteRender = Obj.GetComponent<SpriteRenderer>();
            Color matColor = SpriteRender.color;
            matColor.a = 1.0f;
            SpriteRender.color = matColor;
            Obj.transform.position = Hit.transform.position;
        }
        else
        {
            Destroy(Obj);
        }
    }
}
