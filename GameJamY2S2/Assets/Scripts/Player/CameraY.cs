using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour
{
    public float speedFactor;
    private float y;
    private float lowLimit = 80;
    private float highLimit = 290;
    private Vector3 lookRotation = Vector3.zero;

    void Update()
    {
        y = Input.GetAxis("Camera Y");
        lookRotation = new Vector3(y * speedFactor, 0, 0);
        transform.eulerAngles = transform.eulerAngles - lookRotation;
        if (transform.eulerAngles.x > lowLimit && transform.eulerAngles.x < lowLimit + 180)
        {
            transform.eulerAngles = new Vector3(lowLimit, transform.eulerAngles.y, 0);
        }
        if (transform.eulerAngles.x < highLimit && transform.eulerAngles.x > highLimit - 180)
        {
            transform.eulerAngles = new Vector3(highLimit, transform.eulerAngles.y, 0);
        }
    }
}
