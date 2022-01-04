using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{

    void Update()
    {
        var Hor = Input.GetAxis("Horizontal");

        // ** RotateAround(Vector3 point, Vector3 axis, float angle);
        transform.RotateAround(
            this.transform.position,
            Vector3.up,
            50.0f * Hor * Time.deltaTime);
    }
}
