using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Projectile projectile;
    public float horizontalInput;
    public float speed = 40.0f;
    public float backRange = 300.0f;
    public float forwardRange = 15.0f;

    void Start()
    {
        // Regex pebbleNames = new Regex(projectile.namePattern);
        // GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        // foreach (GameObject indObject in allGameObjects)
        // {
        //     if (pebbleNames.IsMatch(indObject.name))
        //     {
        //         Debug.Log(indObject.name);
        //         projectile.allPebbles.Add(indObject);
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // Move back and forth
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * (-speed) * horizontalInput);

        if (transform.position.z > backRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, backRange);
        }

        if (transform.position.z < forwardRange)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                forwardRange
            );
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
