using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private float velocityRatio = 2.0f; // ratio of fruit speed to pebble speed once hit

    private void OnTriggerEnter(Collider other)
    {
        // if collider is pebble
        if (other.gameObject.CompareTag("Pebble"))
        {
            // if pebble collides with fruit, destroy pebble
            if (gameObject.CompareTag("Fruit"))
            {
                Destroy(other.gameObject); // Destroy pebble
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                // Debug.Log("here");
                Debug.Log(rb.isKinematic);
                rb.detectCollisions = true;
                // var fruitInfo = GameObject.Find("Fruit");
                // var fruitScript = fruitInfo.GetComponent<MoveForward>();
                // var fruitScript = gameObject.GetComponent<MoveForward>();
                // fruitScript.speed = 100.0f;
                Vector3 setVelocity = new Vector3(
                    0,
                    0,
                    (-other.gameObject.GetComponent<MoveForward>().speed / velocityRatio)
                );
                rb.velocity = setVelocity;

                Debug.Log(rb.velocity);
                // Debug.Log("Pebble collided with fruit!!");
            }
            // if pebble collides with eagle, destroy both
            else if (gameObject.CompareTag("Eagle"))
            {
                // Debug.Log("Pebble collided with eagle");
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
