using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    Vector3 add = new Vector3(1f, 1f, 1f);

    // Vector3 add = new Vector3(0.5f, 0.5f, 0.5f);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Chick"))
        {
            if (other.gameObject.CompareTag("Apple")) 
            {
                transform.localScale += new Vector3(add.x, add.y, add.z);
                transform.position = new Vector3(transform.position.x, transform.position.y + add.y / 2, transform.position.z);
            }

            Destroy(other.gameObject);
        }

        else if (gameObject.CompareTag("Eagle"))
        {
            if (other.gameObject.CompareTag("Worm"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Pebble"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameManager.setfree = false;
                GameManager.nearest = null;
            }
        }
        else if (gameObject.CompareTag("Worm"))
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                gameObject.GetComponent<DragAndShoot>().enabled = false;
                GameManager.setfree = false;
                GameManager.nearest = null;
            }
        }
        else if (gameObject.CompareTag("Pebble"))
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                gameObject.GetComponent<DragAndShoot>().enabled = false;
                GameManager.setfree = false;
                GameManager.nearest = null;
            }
            if (other.gameObject.CompareTag("Apple"))
            {
                Destroy(gameObject);
                Rigidbody2D rb = other.gameObject.transform.Find("RedBall").gameObject.GetComponent<Rigidbody2D>();
                rb.gravityScale = 5;
                // Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                // rb.isKinematic = false;
                // rb.detectCollisions = true;
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
