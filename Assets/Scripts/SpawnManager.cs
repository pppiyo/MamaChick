using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.RegularExpressions;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] allPrefabs; // 0: eagle, 1: fruit, 2: pebble, 3: worm

    private int EAGLE_MAX_COUNT = 3;

    // private int FRUIT_MAX_COUNT = 13;
    private int WORM_MAX_COUNT = 10;
    private int PEBBLE_MAX_COUNT = 10;
    private int CHICK_MAX_COUNT = 3;

    private float EAGLE_LIMIT_UP = 100;
    private float EAGLE_LIMIT_DOWN = 65;
    private float EAGLE_LIMIT_LEFT = 300; // horizontal: z: + <- -
    private float EAGLE_LIMIT_RIGHT = 100; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_LEFT = 200; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_RIGHT = 5; // horizontal: z: + <- -
    private float WORM_LIMIT_LEFT = 300; // horizontal: z: + <- -
    private float WORM_LIMIT_RIGHT = 5; // horizontal: z: + <- -
    private float WORM_Y = 3.5f; // horizontal: z: + <- -
    private float PEBBLE_Y = 3.5f; // horizontal: z: + <- -
    private float CHICK_Y = 4.5f; // horizontal: z: + <- -

    private GameObject[] eagles;
    private GameObject[] worms;

    // private GameObject[] fruits;
    private GameObject[] pebbles;
    private GameObject[] chicks;

    private int APPLE_INDEX = 0;
    private int EAGLE_INDEX = 1;
    private int CHICK_INDEX = 2;
    private int MAMA_INDEX = 3;
    private int WORM_INDEX = 4;
    private int PEBBLE_INDEX = 5;

    private GameObject[] apples;

    private List<int> chickLocations = new List<int> { -190, -250, -310 };

    public float cooldown = 60f;
    public float pebbleCoolDown = 10f;
    public float wormCoolDown = 20f;
    public float eagleCoolDown = 5f;
    public int startSetup = 0;

    // Start is called before the first frame update
    void Start() { }

    void Update()
    {
        int spawned = 0;
        apples = GameObject.FindGameObjectsWithTag("Apple");
        if (apples.Length <= 0 && (cooldown <= 0 || startSetup == 0))
        {
            Instantiate(allPrefabs[APPLE_INDEX], new Vector3(0, 50, -89), Quaternion.identity);
            cooldown = 20f;
            spawned = 1;
        }

        

        // Check number of eagles. If there are more than its max, don't spawn more.
        eagles = GameObject.FindGameObjectsWithTag("Eagle");
        if (eagles.Length <= EAGLE_MAX_COUNT && eagleCoolDown <= 0)
        {
            SpawnRandomEagle();
            eagleCoolDown = 5.0f;
            // Debug.Log("Number of eagles: " + eagles.Length);
        }
        else
        {
            eagleCoolDown -= Time.deltaTime;
        }

        // Check number of worms. If there are more than its max, don't spawn more.
        worms = GameObject.FindGameObjectsWithTag("Worm");
        if (worms.Length <= WORM_MAX_COUNT && wormCoolDown <= 0)
        {
            SpawnRandomWorm();
            wormCoolDown = 20.0f;
            // Debug.Log("Number of worms: " + worms.Length);
        }
        else
        {
            wormCoolDown -= Time.deltaTime;
        }

        // Check number of pebbles. If there are more than its max, don't spawn more.
        pebbles = GameObject.FindGameObjectsWithTag("Pebble");
        if (pebbles.Length <= PEBBLE_MAX_COUNT && pebbleCoolDown <= 0)
        {
            SpawnRandomPebble();
            pebbleCoolDown = 10.0f;
            // Debug.Log("Number of pebbles: " + pebbles.Length);
        }
        else
        {
            pebbleCoolDown -= Time.deltaTime;
        }
    }

    void SpawnRandomWorm()
    {
        float y = WORM_Y;
        float z = Random.Range(WORM_LIMIT_LEFT, WORM_LIMIT_RIGHT);
        Vector3 spawnPos = new Vector3(0, y, z);
        Instantiate(allPrefabs[WORM_INDEX], spawnPos, allPrefabs[WORM_INDEX].transform.rotation);
    }

    void SpawnRandomEagle()
    {
        float y = Random.Range(EAGLE_LIMIT_DOWN, EAGLE_LIMIT_UP);
        float z = Random.Range(EAGLE_LIMIT_LEFT, EAGLE_LIMIT_RIGHT);
        Vector3 spawnPos = new Vector3(0, y, z);
        Instantiate(allPrefabs[EAGLE_INDEX], spawnPos, allPrefabs[EAGLE_INDEX].transform.rotation);
    }

    void SpawnRandomPebble()
    {
        float y = PEBBLE_Y;
        float z = Random.Range(PEBBLE_LIMIT_LEFT, PEBBLE_LIMIT_RIGHT);
        Vector3 spawnPos = new Vector3(0, y, z);
        Instantiate(
            allPrefabs[PEBBLE_INDEX],
            spawnPos,
            allPrefabs[PEBBLE_INDEX].transform.rotation
        );
    }
}