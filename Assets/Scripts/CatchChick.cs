using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchChick : MonoBehaviour
{
    [SerializeField] private float descendSpeed = 10.0f;
    [SerializeField] private float dashLoc = 0.0f;
    [SerializeField] private float DASH_LEFT_RANGE = -10.0f;
    [SerializeField] private float DASH_RIGHT_RANGE = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        dashLoc = Random.Range(DASH_LEFT_RANGE, DASH_RIGHT_RANGE);

        if (transform.position.x > dashLoc)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (-descendSpeed));
        }
        
    }
}
