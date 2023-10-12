using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class User
{
    public string userScore = "0";
    public string currentTime = DateTime.Now.ToString();

    // public User() {
    //     totalPoints scores = new totalPoints();
    //     userScore = socres.points.ToString();
    //     // userScore = player.scoreText.text;
    // }
}

public class totalPoints : MonoBehaviour
{
    public int points = 0;
    public Text scoreText;

    private User user;

    void Start()
    {
        user = new User();
        UpdateScoreDisplay();
        RestClient.Post(
            // "https://mamachick-ff15d-default-rtdb.firebaseio.com/" + playerName + ".json",
            "https://mamachick-ff15d-default-rtdb.firebaseio.com/.json",
            user
        );
    }

    //void update()
    //{
    //    // 初始化得分显示
    //    UpdateScoreDisplay();
    //}

    // 增加得分的函数
    public void AddScore(int point)
    {
        points += point;
        UpdateScoreDisplay();
    }

    // 更新得分显示的函数
    private void UpdateScoreDisplay()
    {
        Debug.Log("Total Score: " + points.ToString());
        scoreText.text = "Total Score: " + points.ToString();
        user.userScore = points.ToString();
    }
}
