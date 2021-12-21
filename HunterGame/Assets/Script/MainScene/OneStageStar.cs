    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class OneStageStar : MonoBehaviour
    {
        public Image FirstImage;
        public Image SecondImage;
        public Image ThirdImage;
        public Image InFirstImage;
        public Image InSecondImage;
        public Image InThirdImage;
        public Sprite Star;
        void Start()
        {
            Debug.Log("РћПыСп");
            Debug.Log(GameManager.GetInstance.StageInfoList[0].FirstStar);
            for(int i =0; i< GameManager.GetInstance.MaxLevel;++i)
            {
                 if (GameManager.GetInstance.StageInfoList[i].FirstStar == true)
                 {
                     FirstImage.sprite = Star;
                     InFirstImage.sprite = Star;
                 }
                 if (GameManager.GetInstance.StageInfoList[i].TwoStar == true)
                 {
                     SecondImage.sprite = Star;
                     InSecondImage.sprite = Star;
                 }
                 if (GameManager.GetInstance.StageInfoList[i].TreeStar == true)
                 {
                     ThirdImage.sprite = Star;
                     InThirdImage.sprite = Star;
                 }

                 if (GameManager.GetInstance.StageInfoList[0].Vitory == true)
                 {
                     GameObject.Find("UIManager").GetComponent<StageManager>().NextLevel();
                 }
            }
           


        }
    }
