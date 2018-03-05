using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraX : MonoBehaviour
{
    public float speedFactor;
    private float x;
    private Vector3 lookRotation = Vector3.zero;

    void Update()
    {
        x = Input.GetAxis("Camera X");
        lookRotation = new Vector3(0, (x * -1) * speedFactor, 0);
        transform.eulerAngles = transform.eulerAngles - lookRotation;
    }
}
