using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;

    public bool climbing;
    public float bounceHeight;

    private Vector3 moveDirection = Vector3.zero;
    private float YVel;
    private float speedRef;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speedRef = speed;
        climbing = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Walk"))
        {
            speed = speedRef / 3;
        }
        else
        {
            speed = speedRef;
        }
        CharacterController controller = GetComponent<CharacterController>();

        if (!climbing)
        {    
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    YVel = jumpSpeed;
                }
            }
            YVel -= gravity * Time.deltaTime;
            moveDirection.y = YVel;
        }

        if (climbing)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown("g"))
        {
            //SetClimbing();
        }

        if (Input.GetKeyDown("b"))
        {
            Bounce();
        }
    }

    public void SetClimbing(bool climb)
    {
        Debug.Log("climb set");
        climbing = climb;
    }

    public void Bounce()
    {
        YVel = bounceHeight;
    }
}
