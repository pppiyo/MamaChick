using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftLimit = 300; // horizontal: z: + <- -
    private float rightLimit = -315; // horizontal: z: + <- -
    private float groundLimit = -0.1f; // horizontal: y

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (
            transform.position.z > leftLimit
            || transform.position.z < rightLimit
            || transform.position.y < groundLimit
        )
        {
            Destroy(gameObject);
        }
    }
}
