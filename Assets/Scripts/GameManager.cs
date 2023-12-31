using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;


[System.Serializable]
public class GameReport
{
    public int scores;
    public string endTime;
    public string startTime;
    public int chickRemain;
    public float timeRemain;
    public string level;
    public bool success;

    public GameReport(float currentTime, bool success)
    {
        scores = GlobalVariables.scores;
        endTime = DateTime.Now.ToString();
        startTime = GlobalVariables.startTime;
        chickRemain = GlobalVariables.chick;
        level = GlobalVariables.curLevel;
        if (currentTime < 0)
        {
            timeRemain = 0;
        } else
        {
            timeRemain = currentTime;
        }
        success = success;
    }
}

public class GameManager : MonoBehaviour
{

    public Text countdownText;
    public float gameTime = 120f; // 游戏时间为2分钟
    //public int chickCnt = 3;
    private totalPoints p;

    private float currentTime = 0f;
    private bool isGameOver = false;
    //private bool spawn_eagle = false;

    private void PostToDB(float currentTime, bool success)
    {
        GameReport gameReport = new GameReport(currentTime, success);
        RestClient.Post(
            "https://mamachick-ff15d-default-rtdb.firebaseio.com/.json",
            gameReport
        );
    }

    void Start()
    {
        p = GetComponent<totalPoints>();
        currentTime = gameTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                PostToDB(currentTime, false);
                EndGame();
            }
        }
        if (GlobalVariables.addScore)
        {
            GlobalVariables.addScore = false;
            p.AddScore(1);
        }
        if (p.points == 3)
        {
            // win this game
            GlobalVariables.win = true;
            PostToDB(currentTime, true);
        }
        if (GlobalVariables.win)
        {
            GlobalVariables.win = false;
            WinGame();
        }
        if (GlobalVariables.chick <= 0)
        {
            GlobalVariables.chick = 3;
            PostToDB(currentTime, false);
            EndGame();
        }
        if (GlobalVariables.tutorialEnd)
        {
            GlobalVariables.tutorialEnd = false;
            EndTutorial();
        }
        if (GlobalVariables.tutorialFailed)
        {
            GlobalVariables.tutorialFailed = false;
            restartTutorial();
        }
    }

    //public bool get_spawn_eagle()
    //{
    //    return spawn_eagle;
    //}

    //public void spawnEagle()
    //{
    //    spawn_eagle = true;
    //}

    //public void spawnDone()
    //{
    //    spawn_eagle = false;
    //}

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        isGameOver = true;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Start Menu");
    }

    public void WinGame()
    {
        // TODO
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Start Menu");
        Debug.Log("you win!");
    }

    public void EndTutorial()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Start Menu");
    }

    public void restartTutorial()
    {
        Debug.Log("called restart");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("tutorial");
    }
}
