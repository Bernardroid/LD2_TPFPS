using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Timer : MonoBehaviour {


    public double startTime;
    double timeLeft;
    public bool timeRunning;
    public bool gameOver;

    public Text timeText;

    private void Start()
    {
        gameOver = false;
        startTime = 10.00;
        timeLeft = startTime;
        timeRunning = false;
        timeText.text = startTime.ToString();
        StartCoroutine(StartTimer());
    }

    void Update () {

        if(timeRunning && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                gameOver = true;
                timeLeft = 0;
            }

            timeText.text = timeLeft.ToString("F2");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeRunning = !timeRunning;
        }
	}

    IEnumerator StartTimer()
    {
        Debug.Log("CINCO!");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("CUATRO!");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("TRES!");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("DOS!");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("UNO!");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("EMPIEZA");
        timeRunning = true;
    }
}
