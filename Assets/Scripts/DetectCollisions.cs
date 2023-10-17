using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    Vector3 add = new Vector3(5f, 5f, 5f);

    // Vector3 add = new Vector3(0.5f, 0.5f, 0.5f);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Chick") && other.gameObject.CompareTag("Apple"))
        {
            transform.localScale += new Vector3(add.x, add.y, add.z);
            Destroy(other.gameObject);
        }

        if (gameObject.CompareTag("Eagle"))
        {
            if (other.gameObject.CompareTag("Apple"))
            {
                return;
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
