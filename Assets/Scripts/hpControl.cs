using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class hpControl : MonoBehaviour
{
    private cubeHealth health;
<<<<<<< HEAD
    private totalPoints p;
=======
    //private totalPoints p;
>>>>>>> master
    private chickMP MP;
    private Vector3 originalScale;
    //public ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        health = GetComponent<cubeHealth>();
        MP = GetComponent<chickMP>();
<<<<<<< HEAD
        p = GetComponent<totalPoints>();
=======
        //p = GetComponent<totalPoints>();
>>>>>>> master
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Worm")) 
        {
            if (originalScale.x < 10)
            {
                transform.localScale = new Vector3(
                originalScale.x + 1,
                originalScale.y + 1,
                originalScale.z + 1
                );
                Vector3 currentPosition = transform.position;
                currentPosition.y = transform.localScale.y / 2;
                transform.position = currentPosition;
                originalScale = transform.localScale;
            }
            health.FeedChick(50f);
            //health.hp = health.hp + 10;
            Destroy(collision.gameObject);
            // ObjectSpawner.instance.ObjectDestroyed();
        }

        string objectName = collision.gameObject.name;
        if (objectName.StartsWith("Fruit"))
        {
            // 获取 "Fruit" 后面的数字部分
            string numericPart = objectName.Substring("Fruit".Length + 1);
            Debug.Log(numericPart);
            char[] numericPart_;

            string mp = Regex.Replace(objectName, "[^0-9]", "");
            
            int numericValue;
            Debug.Log("yt68ff76r58r7");
            Debug.Log(mp);
            if (int.TryParse(mp, out numericValue))
            {
                Debug.Log("Detected 'apple' with numeric part: " + numericValue);
                // 在这里你可以使用 numericValue，它包含了 "apple" 后面的数字
            }
            else
            {
                Debug.LogWarning("Failed to parse numeric part: " + numericPart);
            }
            // deal with 21 game logic
            if (MP.mp + numericValue == 21)
            {
                MP.AddPoint(numericValue);
                // totoal point + 1
<<<<<<< HEAD
                p.AddScore(1);
                if (p.points == 3)
                {
                    // win this game
                    GameManager.instance.WinGame();
                }
=======
                GlobalVariables.addScore = true;
                //p.AddScore(1);
                //if (p.points == 3)
                //{
                //    // win this game
                //    GlobalVariables.win = true;
                //}
>>>>>>> master
            } else if (MP.mp + numericValue < 21)
            {
                MP.AddPoint(numericValue);
            } else
            {
                // lose one chick
                Destroy(gameObject);
                // #chick = 0, game over
<<<<<<< HEAD
                GameManager.instance.chickDestory();
=======
                GlobalVariables.chick--;
>>>>>>> master
            }
            Destroy(collision.gameObject);
        }
    }
}
