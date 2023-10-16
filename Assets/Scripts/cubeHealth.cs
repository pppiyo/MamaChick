using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
=======
using UnityEngine.SceneManagement;
>>>>>>> master

public class cubeHealth : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHp = 100f;
    public float curHP = 100f;
    public float decreaseRatePerMinute = 100f;

    void Start()
    {
        healthSlider.maxValue = maxHp;
        healthSlider.value = curHP;
        healthSlider.fillRect.gameObject.SetActive(true);
        StartCoroutine(DecreaseHPOverTime());
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator DecreaseHPOverTime()
    {
        while (curHP > 0)
        {
            float decreaseAmount = decreaseRatePerMinute * (Time.deltaTime / 60f); // 计算每帧应该下降的量
            curHP -= decreaseAmount;
            // 更新显示HP的UI或进行其他处理
            //Debug.Log("Current HP: " + curHP);
            healthSlider.fillRect.gameObject.SetActive(true);
            healthSlider.value = curHP;

            if (curHP <= 0)
            {
                curHP = 0;
                // 物体被销毁
                Destroy(gameObject);
<<<<<<< HEAD
=======
                if (SceneManager.GetActiveScene().name == "tutorial")
                {
                    GlobalVariables.tutorialEnd = true;
                } else if (SceneManager.GetActiveScene().name == "main")
                {
                    GlobalVariables.chick--;
                }
                
>>>>>>> master
            }

            yield return null;
        }
    }

    //void Update()
    //{
    //    healthSlider.fillRect.gameObject.SetActive(true);
    //    healthSlider.value = curHP;
    //}

    public void FeedChick(float amount)
    {
        if (curHP >= 100f)
        {
            return;
        }
        curHP += amount;
        if (curHP >= 100f)
        {
            curHP = 100f;
        }
        healthSlider.fillRect.gameObject.SetActive(true);
        healthSlider.value = curHP;
        //if (currentFedAmount >= amountToBeFed)
        //{
        //    gameManager.AddScore(amountToBeFed);
        //    Destroy(gameObject, 0.1f);
        //}
    }
}
