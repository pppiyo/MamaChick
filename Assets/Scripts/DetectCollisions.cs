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
            if (other.gameObject.CompareTag("Fence"))
            {
                Debug.Log("Fence Check");
                Debug.Log(gameObject.tag);
                if (
                    gameObject.CompareTag("trajectoryWorm")
                    || gameObject.CompareTag("trajectoryPebble")
                    || gameObject.CompareTag("Pebble")
                    || gameObject.CompareTag("Worm")
                )
                {
                    Destroy(gameObject);
                }
            }

            if (gameObject.CompareTag("Eagle"))
            {
                if (other.gameObject.CompareTag("trajectoryPebble"))
                {
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.CompareTag("Pebble"))
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.CompareTag("Chick"))
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
            }

            if (other.gameObject.CompareTag("Pebble"))
            {
                // if pebble collides with fruit, destroy pebble
                if (
                    gameObject.CompareTag("Fruit1")
                    || gameObject.CompareTag("Fruit2")
                    || gameObject.CompareTag("Fruit3")
                    || gameObject.CompareTag("Fruit4")
                    || gameObject.CompareTag("Fruit5")
                    || gameObject.CompareTag("Fruit6")
                    || gameObject.CompareTag("Fruit7")
                    || gameObject.CompareTag("Fruit8")
                    || gameObject.CompareTag("Fruit9")
                    || gameObject.CompareTag("Fruit10")
                    || gameObject.CompareTag("Fruit11")
                    || gameObject.CompareTag("Fruit12")
                    || gameObject.CompareTag("Fruit13")
                )
                {
                    Destroy(other.gameObject); // Destroy pebble
                    Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.detectCollisions = true;

                    Vector3 setVelocity = other.gameObject.GetComponent<Rigidbody>().velocity;
                    rb.velocity = setVelocity;
                    gameObject.GetComponent<SphereCollider>().isTrigger = false;
                }
            }
        }
    }
}
