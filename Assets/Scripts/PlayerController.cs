using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 40.0f;
    public float backRange = 300.0f;
    public float forwardRange = 15.0f;

    void Start() { }

    // todo: when grab worm and pebble, make them use gravity. // currently, they are kinematic and don't use gravity.
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
    }
}
