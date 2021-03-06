using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float minSpeed;
    public float turningSpeed;
    public float maxSpeed;
    //private Vector3 rotation;
    //private float rotationAngle = 0.0f;
    //private float gravity = -9.8f;

    private void Start()
    {
        Score.PlayerScore = 0;
    }

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
                    speed += 0.1f;
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
                    speed -= 0.1f;
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
                    speed -= 0.1f;
                    controller.Move(this.transform.forward * speed * Time.deltaTime);
                    //Debug.Log(speed);
                }
                else if (speed < 0)
                {
                    speed += 0.1f;
                    controller.Move(this.transform.forward * speed * Time.deltaTime);
                    //Debug.Log(speed);
                }
                else
                {
                    speed = 0.0f;
                }
            }

        //if (speed > 0)
        //{
        //    transform.Rotate(rotationAngle += speed, 0.0f, 0.0f);
        //    Debug.Log(rotationAngle);
        //}
        //else
        //{
        //    transform.Rotate(rotationAngle -= speed, 0.0f, 0.0f);
        //}

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        this.transform.localEulerAngles = tempR;
    }
}
