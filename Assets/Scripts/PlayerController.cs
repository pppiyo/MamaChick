using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject[] worms;
    private GameObject[] pebbles;
    public float speed = 40.0f;
    private Vector3 moveDirection;
    private float horizontalInput;
    private float MAMA_RIGHT_BOUNDARY = -10.0f;
    private float MAMA_SIZE_OFFSET = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();

        pebbles  = GameObject.FindGameObjectsWithTag("Pebble");
        worms  = GameObject.FindGameObjectsWithTag("Worm");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(pebbles.Length);
            GameManager.nearest = FindNearestThrowable();
        }

        if (GameManager.nearest != null && GameManager.setfree == false)
        {
            GameManager.nearest.GetComponent<DragAndShoot>().enabled = true;
            GameManager.nearest.transform.position = new Vector3(transform.position.x, transform.position.y + MAMA_SIZE_OFFSET, transform.position.z);
        }
    }

    

    private void HorizontalMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        if (horizontalInput != 0)
        {
            moveDirection = new Vector3(horizontalInput, 0f, 0f);
            moveDirection = moveDirection.normalized;
        }

        transform.Translate(movement);

        if (transform.position.x >= MAMA_RIGHT_BOUNDARY)
        {
            transform.position = new Vector3(MAMA_RIGHT_BOUNDARY, transform.position.y, transform.position.z);
        }

    }

    // private void PickUp()
    // {

    //     GameObject nearest = FindNearestThrowable();

    //     if (nearest != null)
    //     {
    //         nearest.transform.position = transform.position + new Vector3(0, 15, 0);
    //     }
    // }

    private GameObject FindNearestThrowable()
    {
        GameObject nearest = null;
        float minDistance = 60f;
        Vector2 currentPosition = transform.position;

        foreach (GameObject pebble in pebbles)
        {
            float distance = Vector2.Distance(pebble.transform.position, currentPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = pebble;
            }
        }

        foreach (GameObject worm in worms)
        {
            float distance = Vector2.Distance(worm.transform.position, currentPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = worm;
            }
        }
        // Debug.Log(nearest);
        return nearest;
    }
}

