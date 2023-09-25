using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Projectile : MonoBehaviour
{
    public float depth;
    public float spring;
    public float damper;
    public bool ctrlInput;
    public float minDistance;
    public float maxDistance;
    public float releaseDelay;
    public GameObject SlingshotHook;
    public string namePattern;
    public Vector3 boxSize;
    public Vector3 unHookBoundary;
    private bool isPressed = false;
    private Vector3 mousePosition;
    private List<GameObject> allPebbles = new List<GameObject>();

    void Start()
    {
        Debug.Log("Projectile Script Set!");
        //SlingshotHook = GameObject.Find("SlingshotHook");
        Debug.Log(SlingshotHook.name);
        Regex PebbleNames = new Regex(namePattern);
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject indObject in allGameObjects)
        {
            if (PebbleNames.IsMatch(indObject.name))
            {
                allPebbles.Add(indObject);
            }
        }
    }

    IEnumerator UnHookProjectile(GameObject indPebble)
    {
        yield return new WaitForSeconds(releaseDelay);
        Debug.Log("Unhooking the projectile");
        DestroyImmediate(indPebble.GetComponent<SpringJoint>());

    }

    void OnMouseDown()
    {
        isPressed = true;
        Debug.Log("mouse down");
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
                StartCoroutine(UnHookProjectile(indPebble));
                break;
            }
        }
    }

    void Update()
    {
        Regex PebbleNames = new Regex(namePattern);
        allPebbles.Clear();
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject indObject in allGameObjects)
        {
            if (PebbleNames.IsMatch(indObject.name))
            {
                allPebbles.Add(indObject);
            }
        }
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize);
        Collider[] projectiles = Physics.OverlapBox(transform.position, unHookBoundary);

        ctrlInput =
            Input.GetButtonDown("Fire1")
            || Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonUp(0);

        // Break the Hook if its nearby the slingshot hook
        if (!isPressed)
            foreach (Collider collider in projectiles)
            {
                if (PebbleNames.IsMatch(collider.gameObject.name))
                {
                    if (
                        collider.gameObject.GetComponent<SpringJoint>() != null
                        && !Input.GetMouseButtonDown(0)
                    )
                    {
                        // Debug.Log("Unhooking the projectile");
                        // DestroyImmediate(collider.gameObject.GetComponent<SpringJoint>());
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
                    foreach (GameObject indPebbles in allPebbles)
                    {
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
                        collider.gameObject.transform.position = new Vector3(
                            SlingshotHook.transform.position.x,
                            SlingshotHook.transform.position.y - 8,
                            SlingshotHook.transform.position.z
                        );
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
            // mousePosition = new Vector3(-1*Input.mousePosition.x, Input.mousePosition.y, 0);
            foreach (GameObject indPebbles in allPebbles)
            {
                if (indPebbles.GetComponent<SpringJoint>() != null)
                {
                   mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
                    indPebbles.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                }
            }
        }
    }
}
