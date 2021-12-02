using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float CameraSpeed;
    public Camera mainCamera;

    private void Start()
    {
        CameraSpeed = 10.0f;
    }
    void Update()
    {
        mainCamera.transform.position += Vector3.right * CameraSpeed * Time.deltaTime;
    }
}
