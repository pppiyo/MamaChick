using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float depth; 
    public float spring;
    public float damper;
    public bool ctrlInput;
    public float minDistance;
    public float maxDistance;
    public GameObject SlingshotHook;
    public string namePattern;
    public Vector3 boxSize;
    public Vector3 unHookBoundary;
    private bool isPressed = false;
    private Vector3 mousePosition;
    private List<GameObject> allPebbles = new List<GameObject>();
    
    void Start()
    {
        SlingshotHook = GameObject.Find("SlingshotHook");
        Regex PebbleNames = new Regex(namePattern);
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject indObject in allGameObjects)
        {
            if (PebbleNames.IsMatch(indObject.name))
            {
                Debug.Log(indObject.name);
                allPebbles.Add(indObject);
            }
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        foreach (GameObject indPebble in allPebbles)
        {
            if (indPebble.GetComponent<SpringJoint>() != null)
            {
                indPebble.GetComponent<Rigidbody>().isKinematic = true;
                break;
            }
        }
    }

    void OnMouseUp()
    {
        isPressed = false;
        foreach (GameObject indPebble in allPebbles)
        {
            if (indPebble.GetComponent<SpringJoint>() != null)
            {
                indPebble.GetComponent<Rigidbody>().isKinematic = false;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Regex PebbleNames = new Regex(namePattern);
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        allPebbles.Clear();
        foreach (GameObject indObject in allGameObjects)
        {
            if (PebbleNames.IsMatch(indObject.name))
            {
                Debug.Log(indObject.name);
                allPebbles.Add(indObject);
            }
        }
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize);
        Collider[] projectiles = Physics.OverlapBox(transform.position, unHookBoundary);


        ctrlInput = Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0);

        // Break the Hook if its nearby the slingshot hook
        if(!isPressed)
        foreach(Collider collider in projectiles)
        {
            if (PebbleNames.IsMatch(collider.gameObject.name))
            {
                if (collider.gameObject.GetComponent<SpringJoint>() != null && !Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Unhooking the projectile");
                    DestroyImmediate(collider.gameObject.GetComponent<SpringJoint>());
                    break;
                }
            }
        }

        foreach (Collider collider in colliders)
        {
            // Selects only pebbles within the collider
            if (PebbleNames.IsMatch(collider.gameObject.name))
            {
                if (ctrlInput)
                {
                    bool anyConnected = false;
                    Debug.Log("gekkk1");
                    foreach (GameObject indPebbles in allPebbles)
                    {
                        Debug.Log(indPebbles.name);
                        if (indPebbles.GetComponent<SpringJoint>() != null)
                        {
                            anyConnected = true;
                            break;
                        }
                    }
                    if (!anyConnected)
                    {
                        Debug.Log("Hooking new Projectile");
                        collider.gameObject.AddComponent<SpringJoint>();
                        collider.gameObject.transform.position = new Vector3 (SlingshotHook.transform.position.x, SlingshotHook.transform.position.y - 3, SlingshotHook.transform.position.z);
                        collider.gameObject.GetComponent<SpringJoint>().connectedBody = SlingshotHook.GetComponent<Rigidbody>();
                        collider.gameObject.GetComponent<SpringJoint>().spring = spring;
                        collider.gameObject.GetComponent<SpringJoint>().damper = damper;
                        collider.gameObject.GetComponent<SpringJoint>().minDistance = minDistance;
                        collider.gameObject.GetComponent<SpringJoint>().maxDistance = maxDistance;
                    }
                }
            }
        }
        if (isPressed)
        {
            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
            foreach (GameObject indPebbles in allPebbles)
            {
                if (indPebbles.GetComponent<SpringJoint>() != null)
                {
                    indPebbles.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                }
            }
        }
    }
}
