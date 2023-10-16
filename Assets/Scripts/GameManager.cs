using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
<<<<<<< HEAD
{
    // 声明一个静态实例，以便其他类可以访问
    public static GameManager instance;
=======
{ 
>>>>>>> master

    public Text countdownText;
    public float gameTime = 120f; // 游戏时间为2分钟
    public int chickCnt = 3;
<<<<<<< HEAD

    private float currentTime = 0f;
    private bool isGameOver = false;

    void Start()
    {
=======
    private totalPoints p;

    private float currentTime = 0f;
    private bool isGameOver = false;
    //private bool spawn_eagle = false;

    void Start()
    {
        p = GetComponent<totalPoints>();
>>>>>>> master
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
                EndGame();
            }
        }
<<<<<<< HEAD
    }

    public void chickDestory()
    {
        chickCnt--;
        if (chickCnt <= 0)
        {
            EndGame();
        }
    }

=======
        if (GlobalVariables.addScore)
        {
            GlobalVariables.addScore = false;
            p.AddScore(1);
        }
        if (p.points == 3)
        {
            // win this game
            GlobalVariables.win = true;
        }
        if (GlobalVariables.win)
        {
            GlobalVariables.win = false;
            WinGame();
        }
        if (GlobalVariables.chick <= 0)
        {
            GlobalVariables.chick = 3;
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

>>>>>>> master
    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        isGameOver = true;
<<<<<<< HEAD
        SceneManager.LoadScene("AttackingEagle");
=======
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Start Menu");
>>>>>>> master
    }

    public void WinGame()
    {
<<<<<<< HEAD
        Debug.Log("you win!");
    }
=======
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
>>>>>>> master
}
