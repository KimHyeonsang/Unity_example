using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitory : MonoBehaviour
{
    public bool OneStar;
    public bool TwoStar;
    public bool TreeStar;

    public Image firstImage;
    public Sprite Star;
    void Start()
    {
        OneStar = false;
        TwoStar = false;
        TreeStar = false;

        GameObject Obj = GameObject.Find("SpownCanvas");
        Obj.SetActive(false);
    }

    void Update()
    {
        Time.timeScale = 0;


   //   if (GameManager.GetInstance.KillCount >= GameManager.GetInstance.MaxZombiNumber)
   //   {
   //       firstImage.sprite = Star;
   //
   //   }
    }

    public void OnVitory()
    {
        GameObject Obj = gameObject;
        Obj.SetActive(true);
    }
}
