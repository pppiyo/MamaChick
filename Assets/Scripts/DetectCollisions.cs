using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    Vector3 add = new Vector3(5f, 5f, 5f);

    // Vector3 add = new Vector3(0.5f, 0.5f, 0.5f);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Apple"))
        {
            transform.localScale += new Vector3(add.x, add.y, add.z);
            // gameObject.GetComponent<PlayerBehaviour>().AddScore();
        }
        Destroy(other.gameObject);
    }
}
