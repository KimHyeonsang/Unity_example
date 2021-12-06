using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class text : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        // ¾À º¯°æ
        // SceneManager.LoadScene("...");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 10.0f * Time.deltaTime;

        float Hor = Input.GetAxisRaw("Horizontal");
         float Ver = Input.GetAxisRaw("Vertical");
     
         mainCamera.transform.position = new Vector3(
             mainCamera.rect.width/ mainCamera.rect.height * mainCamera.orthographicSize * Hor,
             mainCamera.orthographicSize * Ver,
            0.0f);
    }
}
