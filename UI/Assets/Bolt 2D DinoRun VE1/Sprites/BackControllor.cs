using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackControllor : MonoBehaviour
{
    Vector3 mainCameraSpeed;
    private PlayerControllor player;
    private void Start()
    {
        player = GameObject.Find("GameObject").GetComponent<PlayerControllor>();
        mainCameraSpeed = Vector3.right * 10.0f;
    }
    void Update()
    {
        if (player.bDie == false)
        {
            transform.position += Vector3.left * 0.2f * Time.deltaTime;

            transform.position += mainCameraSpeed * Time.deltaTime;
        }
    }
    public void RePlay()
    {
        Start();
        transform.position = new Vector3(-5.0f, 0.0f, -0.5f);
    }
}
