using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackControllor : MonoBehaviour
{
    Vector3 mainCameraSpeed;
    private void Start()
    {
        mainCameraSpeed = Vector3.right * 10.0f;
    }
    void Update()
    {
        transform.position += Vector3.left * 0.2f * Time.deltaTime;

        transform.position += mainCameraSpeed * Time.deltaTime;
    }
}
