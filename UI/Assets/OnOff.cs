using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    [SerializeField] private GameObject Obj;
    private bool Check;
    private void Awake()
    {
        Obj = GameObject.Find("MenuCanvas");
    }
    void Start()
    {
        Obj.transform.Find("Menu");
        Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Check)
        {
            if (transform.position.x < 180)
            {
                Obj.transform.Translate(5.0f * Time.deltaTime, 0.0f, 0.0f);
            }
            else
                Check = false;
        }
        else
        {
            if (transform.position.x > 11)
            {
                Obj.transform.Translate(-5.0f * Time.deltaTime, 0.0f, 0.0f);
            }
            else
                Check = true;
        }
    }
}
