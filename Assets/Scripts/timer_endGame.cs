using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_endGame : MonoBehaviour
{
    public Text Timer;
    private float timeInit = 0f;

    void Update()
    {
        timeInit += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeInit / 60);
        int seconds = Mathf.FloorToInt(timeInit % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer.text = timerString;
    }
}
