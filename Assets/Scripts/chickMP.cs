using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chickMP : MonoBehaviour
{
    public int mp = 0;
    public Text pointText;
    void Start()
    {
        UpdatePointDisplay();
    }

    //void update()
    //{
    //    // 初始化得分显示
    //    UpdateScoreDisplay();
    //}

    // 增加得分的函数
    public void AddPoint(int point)
    {
        mp += point;
        UpdatePointDisplay();
    }

    // 更新得分显示的函数
    private void UpdatePointDisplay()
    {
        //Debug.Log("Total Score: " + points.ToString());
        pointText.text = mp.ToString();
    }
}
