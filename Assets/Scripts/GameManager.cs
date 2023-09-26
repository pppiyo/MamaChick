using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 声明一个静态实例，以便其他类可以访问
    public static GameManager instance;

    public Text countdownText;
    public float gameTime = 120f; // 游戏时间为2分钟
    public int chickCnt = 3;

    private float currentTime = 0f;
    private bool isGameOver = false;

    void Start()
    {
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
    }

    public void chickDestory()
    {
        chickCnt--;
        if (chickCnt <= 0)
        {
            EndGame();
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        isGameOver = true;
        SceneManager.LoadScene("AttackingEagle");
    }

    public void WinGame()
    {
        Debug.Log("you win!");
    }
}
