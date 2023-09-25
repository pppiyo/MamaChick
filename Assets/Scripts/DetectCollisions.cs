using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private float velocityRatio = 2.0f; // ratio of fruit speed to pebble speed once hit

    private void OnTriggerEnter(Collider other)
    {
        // if collider is pebble
        if (other.gameObject != null)
        {
            if (other.gameObject.CompareTag("Pebble"))
            {
                // if pebble collides with fruit, destroy pebble
                if (gameObject.CompareTag("Fruit"))
                {
                    Destroy(other.gameObject); // Destroy pebble
                    Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.detectCollisions = true;

                    Vector3 setVelocity = new Vector3(
                        0,
                        0,
                        -20 // to be replaced with actual pebble speed reduced by half
                    // (-other.gameObject.GetComponent<MoveForward>().speed / velocityRatio) // get pebble speed for testing purposes (since peeble shouldn't use MoveForward script!)
                    );
                    rb.velocity = setVelocity;
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
}
