using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HpControlTutorial : MonoBehaviour
{
    private cubeHealth health;
    private totalPoints p;
    private chickMP MP;
    private Vector3 originalScale;
    //public ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        health = GetComponent<cubeHealth>();
        MP = GetComponent<chickMP>();
        p = GetComponent<totalPoints>();
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
                p.AddScore(1);
                if (p.points == 1)
                {
                    // win this game
                    GameManager.instance.EndTutorial();
                }
            }
            else if (MP.mp + numericValue < 21)
            {
                MP.AddPoint(numericValue);
            }
            else
            {
                // lose one chick
                Destroy(gameObject);
                // #chick = 0, game over
                GameManager.instance.chickDestory();
            }
            Destroy(collision.gameObject);
        }
    }
}
