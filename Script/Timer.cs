using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Timer: MonoBehaviour
{
    private float maxTime = 1;
    private float timer = 0;

    public float seconds = 0;
    public float minutes = 0;

    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        //Checks if game over
        if (GameManager.Instance.isGameOver != true)
        {
            GameTimer();
            //Changes the timer depending on the the minutes and seconds
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    timeText.text = "Time: 0" + minutes.ToString() + " : 0" + seconds.ToString();
                }
                else if (seconds >= 10)
                    timeText.text = "Time: 0" + minutes.ToString() + " : " + seconds.ToString();
            }
            else if (minutes >= 10) 
            {
                if (seconds < 10)
                {
                    timeText.text = "Time: " + minutes.ToString() + " : 0" + seconds.ToString();
                }
                else if (seconds >= 10)
                    timeText.text = "Time: " + minutes.ToString() + " : " + seconds.ToString();
            }


                GameMinutes();
        }
    }

    void GameTimer()
    {
        if (timer > maxTime)
        {
            seconds += 1;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void GameMinutes() 
    {
        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        
        }

    }
}
