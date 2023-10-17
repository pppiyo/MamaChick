using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.RegularExpressions;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] allPrefabs; // 0: eagle, 1: fruit, 2: pebble, 3: worm

    private int EAGLE_MAX_COUNT = 3;

    // private int FRUIT_MAX_COUNT = 13;
    private int WORM_MAX_COUNT = 3;
    private int PEBBLE_MAX_COUNT = 5;
    // private int CHICK_MAX_COUNT = 3;

    private float EAGLE_LIMIT_UP = 100;
    private float EAGLE_LIMIT_DOWN = 70;
    private float EAGLE_LIMIT_LEFT = -250; // horizontal: z: + <- -
    private float EAGLE_LIMIT_RIGHT = -100; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_LEFT = -250; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_RIGHT = -10; // horizontal: z: + <- -
    private float WORM_LIMIT_LEFT = -250; // horizontal: z: + <- -
    private float WORM_LIMIT_RIGHT = -10; // horizontal: z: + <- -
    private float WORM_Y = 3.5f; // horizontal: z: + <- -
    private float PEBBLE_Y = 3.5f; // horizontal: z: + <- -
    private float CHICK_Y = 4.5f; // horizontal: z: + <- -

    private GameObject[] eagles;
    private GameObject[] worms;

    // private GameObject[] fruits;
    private GameObject[] pebbles;
    private GameObject[] chicks;

    private int PEBBLE_INDEX = 0;
    private int WORM_INDEX = 1;
    private int CHICK_INDEX = 2;
    private int EAGLE_INDEX = 3;
    private int APPLE_1_INDEX = 4;
    private int APPLE_2_INDEX = 5;
    private int APPLE_3_INDEX = 6;
    private int APPLE_4_INDEX = 7;
    private int APPLE_5_INDEX = 8;
    private int APPLE_6_INDEX = 9;
    private int APPLE_7_INDEX = 10;
    private int APPLE_8_INDEX = 11;
    private int APPLE_9_INDEX = 12;
    private int APPLE_10_INDEX = 13;
    private int APPLE_11_INDEX = 14;
    private int APPLE_12_INDEX = 15;
    private int APPLE_13_INDEX = 16;

    // private List<int> chickLocations = new List<int> { -190, -250, -310 };

    public float COOL_DOWN = 60f;
    public float PEBBLE_COOL_DOWN = 10f;
    public float WORM_COOL_DOWN = 20f;
    public float EAGLE_COOL_DOWN = 5f;
    public int startSetup = 0;

    public float coolDown;
    public float pebbleCoolDown;
    public float wormCoolDown;
    public float eagleCoolDown;

    // Start is called before the first frame update
    void Start() {
        coolDown = COOL_DOWN;
        pebbleCoolDown = PEBBLE_COOL_DOWN;
        wormCoolDown = WORM_COOL_DOWN; 
        eagleCoolDown = EAGLE_COOL_DOWN;
     }

    void Update()
    {
        // Check number of eagles. If there are more than its max, don't spawn more.
        eagles = GameObject.FindGameObjectsWithTag("Eagle");
        if (eagles.Length <= EAGLE_MAX_COUNT && eagleCoolDown <= 0)
        {
            SpawnRandomEagle();
            eagleCoolDown = EAGLE_COOL_DOWN;
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
            wormCoolDown = WORM_COOL_DOWN;
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
            pebbleCoolDown = PEBBLE_COOL_DOWN;
            // Debug.Log("Number of pebbles: " + pebbles.Length);
        }
        else
        {
            pebbleCoolDown -= Time.deltaTime;
        }
    }

    void SpawnRandomWorm()
    {
        float x = Random.Range(WORM_LIMIT_LEFT, WORM_LIMIT_RIGHT);
        float y = WORM_Y;
        Vector3 spawnPos = new Vector3(x, y, 0);
        Instantiate(allPrefabs[WORM_INDEX], spawnPos, allPrefabs[WORM_INDEX].transform.rotation);
    }

    void SpawnRandomEagle()
    {
        float x = Random.Range(EAGLE_LIMIT_LEFT, EAGLE_LIMIT_RIGHT);
        float y = Random.Range(EAGLE_LIMIT_DOWN, EAGLE_LIMIT_UP);
        Vector3 spawnPos = new Vector3(x, y, 0);
        Instantiate(allPrefabs[EAGLE_INDEX], spawnPos, allPrefabs[EAGLE_INDEX].transform.rotation);
    }

    void SpawnRandomPebble()
    {
        float x = Random.Range(PEBBLE_LIMIT_LEFT, PEBBLE_LIMIT_RIGHT);
        float y = PEBBLE_Y;
        Vector3 spawnPos = new Vector3(x, y, 0);
        Instantiate(
            allPrefabs[PEBBLE_INDEX],
            spawnPos,
            allPrefabs[PEBBLE_INDEX].transform.rotation
        );
    }
}