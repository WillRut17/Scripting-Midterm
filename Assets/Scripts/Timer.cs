using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float remainingTime;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        CalculateTime(remainingTime);

        if (remainingTime > 0)
        {
            remainingTime -= 1 * Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            //add move to game over screen
        }
    }

    void CalculateTime(float timeToCalculate)
    {
        //float minutes = Mathf.FloorToInt(timeToCalculate / 60);
        float seconds = Mathf.FloorToInt(timeToCalculate % 60);
        float milliseconds = timeToCalculate * 100;
        milliseconds = milliseconds % 100;

        //timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }
}
