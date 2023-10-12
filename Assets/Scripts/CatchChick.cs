using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchChick : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 110.0f;
    private float dashLoc = 0.0f;

    // private List<int> chickLocations = new List<int> { -190, -250, -310 };

    // Create a Random object
    // Random random = new Random();

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        // Generate a random index within the valid range of the list
        // int idx = random.Next(0, chickLocations.Count);

        // Retrieve the random number from the list
        // int randomChickLoc = chickLocations[idx];

        dashLoc = Random.Range(-450, -50);

        if (transform.position.z < dashLoc)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (-speed));
        }
    }
}
