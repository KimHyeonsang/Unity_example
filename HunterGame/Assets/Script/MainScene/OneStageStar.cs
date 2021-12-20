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
            if (GameManager.GetInstance.StageOne.FirstStar == true)
            {
                FirstImage.sprite = Star;
                InFirstImage.sprite = Star;
            }
            if (GameManager.GetInstance.StageOne.TwoStar == true)
            {
                SecondImage.sprite = Star;
                InSecondImage.sprite = Star;
            }
            if (GameManager.GetInstance.StageOne.TreeStar == true)
            {
                ThirdImage.sprite = Star;
                InThirdImage.sprite = Star;
            }
        
            if(GameManager.GetInstance.StageOne.Vitory == true)
            {
                StageManager.Level++;
            }


        }
    }
