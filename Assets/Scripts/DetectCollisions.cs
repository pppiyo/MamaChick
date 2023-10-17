using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    Vector3 add = new Vector3(5f, 5f, 5f);

    // Vector3 add = new Vector3(0.5f, 0.5f, 0.5f);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Chick"))
        {
            if (other.gameObject.CompareTag("Apple")) 
            {
                transform.localScale += new Vector3(add.x, add.y, add.z);
            }

            Destroy(other.gameObject);
        }

        else if (gameObject.CompareTag("Eagle"))
        {
            if (other.gameObject.CompareTag("Apple"))
            {
                return;
            }
            else if (other.gameObject.CompareTag("Apple"))
            {
                return;
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
                Debug.Log("Worm hit the floor");
                gameObject.GetComponent<DragAndShoot>().enabled = false;
                GameManager.setfree = false;
                GameManager.nearest = null;
            }
        }
        else if (gameObject.CompareTag("Pebble"))
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                Debug.Log("Pebble hit the floor");
                gameObject.GetComponent<DragAndShoot>().enabled = false;
                GameManager.setfree = false;
                GameManager.nearest = null;
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
