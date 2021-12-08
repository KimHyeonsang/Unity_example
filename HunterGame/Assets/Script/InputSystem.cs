using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private GameObject Frefab;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit Hit;
      if(Physics.Raycast(ray,out Hit, Mathf.Infinity))
        {
            Debug.Log("2");
            if (Hit.transform.tag == "Player3")
            {
                Debug.Log("1");
            }
         //   Frefab = Resources.Load("Frefabs/Bird 4 Yellow_0") as GameObject;
         //   GameObject Obj = Instantiate(Frefab);
         //   Obj.transform.position = new Vector3(0, -10.0f, -9.0f);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
