using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float minSpeed;
    public float turningSpeed;
    public float maxSpeed;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 tempR = this.transform.localEulerAngles;
        tempR.y += turningSpeed * Time.deltaTime * horizontal;

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (speed < maxSpeed)
            {
                speed += 0.05f;
                controller.Move(this.transform.forward * speed * forward * Time.deltaTime);
                //Debug.Log(speed);
            }
            else if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                controller.Move(this.transform.forward * speed * forward * Time.deltaTime);
            }
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            if (speed > minSpeed)
            {
                speed -= 0.05f;
                controller.Move(this.transform.forward * speed * -forward * Time.deltaTime);
                //Debug.Log(speed);
            }
            else if (speed <= minSpeed)
            {
                speed = minSpeed;
                controller.Move(this.transform.forward * speed * -forward * Time.deltaTime);
            }
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (speed > 0)
            {
                speed -= 0.05f;
                controller.Move(this.transform.forward * speed * Time.deltaTime);
               //Debug.Log(speed);
            }
            else if (speed < 0)
            {
                speed += 0.05f;
                controller.Move(this.transform.forward * speed * Time.deltaTime);
                //Debug.Log(speed);
            }
            else
            {
                speed = 0.0f;
            }
        }

        this.transform.localEulerAngles = tempR;
    }
}
