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
    public string trajectoryLayer1;
    private int trajectoryLayerIndex1;
    public string trajectoryLayer2;
    private int trajectoryLayerIndex2;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public string namePattern;
    public Vector3 boxSize;
    private bool isPressed = false;
    private float timer = 0f;
    public float interval = 2f;
    private Vector3 mousePosition;
    private List<GameObject> allPebbles = new List<GameObject>();

    void Start()
    {
        Debug.Log("Projectile Script Set!");
        trajectoryLayerIndex1 = LayerMask.NameToLayer(trajectoryLayer1);
        trajectoryLayerIndex2 = LayerMask.NameToLayer(trajectoryLayer2);
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

    IEnumerator UnHookTrajectory(GameObject indPebble)
    {
        indPebble.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(releaseDelay);
        Debug.Log("Unhooking the projectile");
        DestroyImmediate(indPebble.GetComponent<SpringJoint>());
    }

    void OnMouseDown()
    {
        isPressed = true;
        Debug.Log("Mouse down");
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

        ctrlInput =
            Input.GetButtonDown("Fire1")
            || Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonUp(0);

        foreach (Collider collider in colliders)
        {
            timer += Time.deltaTime;
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
                        collider.gameObject.GetComponent<SpringJoint>().connectedBody =
                            SlingshotHook.GetComponent<Rigidbody>();
                        collider.gameObject
                            .GetComponent<SpringJoint>()
                            .autoConfigureConnectedAnchor = false;
                        collider.gameObject.GetComponent<SpringJoint>().anchor =
                            transform.InverseTransformPoint(SlingshotHook.transform.position);
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
                    mousePosition = new Vector3(
                        Input.mousePosition.x,
                        Input.mousePosition.y,
                        depth
                    );
                    indPebbles.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

                    // Trajectory prediction with dummy Projectiles
                    if (timer >= interval)
                    {
                        timer = 0f;
                        Vector3 spawnPosition = indPebbles.transform.position;
                        Quaternion spawnRotation = Quaternion.identity;
                        // Instantiate the prefab.
                        GameObject predictionProjectile;
                        if (indPebbles.tag == "Pebble")
                        {
                            // predictionProjectile = Instantiate(projectilePrefab1, spawnPosition, spawnRotation);
                            //predictionProjectile.gameObject.layer = trajectoryLayerIndex1;
                        }
                        else
                        {
                            predictionProjectile = Instantiate(
                                projectilePrefab2,
                                spawnPosition,
                                spawnRotation
                            );
                            //  predictionProjectile.gameObject.layer = trajectoryLayerIndex2;
                        }
                        // predictionProjectile.name = "newProjectile";
                        // predictionProjectile.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        // predictionProjectile.gameObject.AddComponent<SpringJoint>();
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().connectedBody = SlingshotHook.GetComponent<Rigidbody>();
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().autoConfigureConnectedAnchor = false;
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().anchor = transform.InverseTransformPoint(SlingshotHook.transform.position);
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().spring = spring;
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().damper = damper;
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().minDistance = minDistance;
                        // predictionProjectile.gameObject.GetComponent<SpringJoint>().maxDistance = maxDistance;
                        // StartCoroutine(UnHookTrajectory(predictionProjectile));
                    }
                }
            }
        }
    }
}
