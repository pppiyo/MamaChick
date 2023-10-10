using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalPoints : MonoBehaviour
{
    public int points = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreDisplay();
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
    }
}
