using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerControl : MonoBehaviour
{
    private void Awake()
    {
        //임시 사운드 실행
        SoundManager.GetInstance.Initalize();        
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(Hor * 5.0f * Time.deltaTime,
            0.0f,
            Ver * 5.0f * Time.deltaTime);
    }
}
