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
    private bool isPressed = false;
    private float timer = 0f;
    public float interval = 2f;
    private List<GameObject> allPebbles = new List<GameObject>();
    private Gradient gradient;
    private Color startColor = Color.red;
    private Color endColor = Color.yellow;


    // New Beta Version
    public GameObject pickedPebble; 
    public float pushForce = 4f;
    bool isDragging = false;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 direction;
    private float distance;
    private Vector3 force;
    public int numPoints;
    public float timeStep;
    private LineRenderer projectilePath;
    public float linePoints; 
    private GameObject debugobj;

    void Start()
    {
        gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(startColor, 0f), new GradientColorKey(endColor, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) }
        );
    }

    void OnDragStart()
    {
        // pickedPebble.DesactivateRb();
        Debug.Log("On Drag Start!");
        debugobj = pickedPebble;
        pickedPebble.GetComponent<Rigidbody>().isKinematic = true;
        projectilePath = pickedPebble.GetComponent<LineRenderer>();
        DestroyImmediate(pickedPebble.GetComponent<SpringJoint>());
    }

    void OnDrag()
    {
        Debug.Log("On Drag!");
        endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth));
        pickedPebble.transform.position = endPoint;
        distance = Vector3.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = distance * direction * pushForce;
        Vector3 CalVelocity = (force / pickedPebble.GetComponent<Rigidbody>().mass);
        CalVelocity.y -= 0.19f;
        Vector3[] positions = new Vector3[Mathf.FloorToInt(linePoints / timeStep)];
        Vector3 position = endPoint;
        int i = 0;
        for (float time = 0; time < linePoints; time += timeStep) 
        {
            position.x = 0;
            position.z = endPoint.z + CalVelocity.z * time;
            position.y = endPoint.y + CalVelocity.y * time + ((Physics.gravity.y / 2f) * time * time);
            positions[i] = position;
            i++;
        }
        Debug.Log(positions);
        projectilePath.SetPositions(positions);
        projectilePath.colorGradient = gradient;
    }

    void OnDragEnd()
    {
        Debug.Log("On Drag End!");
        projectilePath.positionCount = 0;
        pickedPebble.GetComponent<Rigidbody>().isKinematic = false;
        pickedPebble.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        pickedPebble = null;
    }

   

    void Update()
    {

        // New Beta Version
        startPoint = SlingshotHook.transform.position;
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

        ctrlInput = Input.GetButtonDown("Fire1");

        if (pickedPebble)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            else if (isDragging && Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }
            else if (isDragging)
            {
                OnDrag();
            }
        }
        else if(ctrlInput)
        foreach (Collider collider in colliders)
        {
            // Selects only pebbles within the collider
            if (PebbleNames.IsMatch(collider.gameObject.name))
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
                        pickedPebble = collider.gameObject;
                        pickedPebble.transform.position = new Vector3(
                            SlingshotHook.transform.position.x,
                            SlingshotHook.transform.position.y,
                            SlingshotHook.transform.position.z
                        );
                        pickedPebble.gameObject.AddComponent<SpringJoint>();
                        pickedPebble.gameObject.GetComponent<SpringJoint>().connectedBody = SlingshotHook.GetComponent<Rigidbody>();
                        pickedPebble.gameObject.GetComponent<SpringJoint>().autoConfigureConnectedAnchor = false;
                        pickedPebble.gameObject.GetComponent<SpringJoint>().anchor = transform.InverseTransformPoint(SlingshotHook.transform.position);
                        pickedPebble.gameObject.GetComponent<SpringJoint>().spring = spring;
                        pickedPebble.gameObject.GetComponent<SpringJoint>().damper = damper;
                        pickedPebble.gameObject.GetComponent<SpringJoint>().minDistance = minDistance;
                        pickedPebble.gameObject.GetComponent<SpringJoint>().maxDistance = maxDistance;
                    }
            }
        }
    }
}
