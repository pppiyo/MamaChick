using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChick : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float turnSpeed; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
