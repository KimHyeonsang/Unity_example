using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;

    private void Start()
    {
        CubePrefab = Resources.Load("Prefabs/Step_12/Cube") as GameObject;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseButtonDown");

            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition);

            RaycastHit Hit;

            if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
            {
                GameObject Obj = Instantiate(CubePrefab);

                Obj.transform.position = Hit.point;
            }
        }
    }
}
