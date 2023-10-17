using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundary : MonoBehaviour
{
    private float LEFT_BOUNDARY = -250;
    
    private float RIGHT_BOUNDARY = 250;

    private float BOTTOM_BOUNDARY = -0.2f;

    private float THROWABLE_RIGHT_BOUNDARY = 0;
    private float THROWABLE_BOTTOM_BOUNDARY = 3;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > RIGHT_BOUNDARY
            || transform.position.x < LEFT_BOUNDARY
            || transform.position.y < BOTTOM_BOUNDARY
        )
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Pebble") || gameObject.CompareTag("Worm"))
        {
            Debug.Log("HI");
            if (transform.position.x > THROWABLE_RIGHT_BOUNDARY
                && transform.position.y <= THROWABLE_BOTTOM_BOUNDARY
            )
            {
                Destroy(gameObject);
            }
        }

    }
}
