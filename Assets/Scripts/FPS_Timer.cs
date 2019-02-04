using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPS_Timer : MonoBehaviour {


    public double startTime;
    public static double timeLeft;
    public bool timeRunning;
    public bool gameOver;

    public Text timeText;
    public Text messageText;
    public SCR_SimpleMove charMoveScript;
    public GameObject btnRestart;

    private void Start()
    {
        gameOver = false;
        timeLeft = startTime;
        timeRunning = false;
        timeText.text = startTime.ToString("F2");
        StartCoroutine(StartTimer());
        btnRestart.SetActive(false);
        Time.timeScale = 1;
        //charMoveScript.enabled = true;
    }

    void Update () {

        if(timeRunning && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0 && !gameOver)
            {
                gameOver = true;
                timeLeft = 0;
                StartCoroutine(ActivateGameOver());
            }

            timeText.text = timeLeft.ToString("F2");
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            timeRunning = !timeRunning;
        }
	}

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ActivateGameOver()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
        btnRestart.SetActive(true);
        charMoveScript.enabled = false;
    }

    IEnumerator StartTimer()
    {
        charMoveScript.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "5";
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "4";
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "3";
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "START!";
        charMoveScript.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        messageText.text = "";
        timeRunning = true;
    }
}
