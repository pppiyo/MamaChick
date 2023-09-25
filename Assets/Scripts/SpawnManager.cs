using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] allPrefabs; // 0: eagle, 1: fruit, 2: pebble, 3: worm

    private int EAGLE_MAX_COUNT = 3;

    // private int FRUIT_MAX_COUNT = 13;
    private int WORM_MAX_COUNT = 15;
    private int PEBBLE_MAX_COUNT = 15;

    private float EAGLE_LIMIT_UP = 100;
    private float EAGLE_LIMIT_DOWN = 65;
    private float EAGLE_LIMIT_LEFT = 300; // horizontal: z: + <- -
    private float EAGLE_LIMIT_RIGHT = 100; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_LEFT = 200; // horizontal: z: + <- -
    private float PEBBLE_LIMIT_RIGHT = 5; // horizontal: z: + <- -
    private float PEBBLE_Y = 1; // horizontal: z: + <- -
    private float WORM_LIMIT_LEFT = 300; // horizontal: z: + <- -
    private float WORM_LIMIT_RIGHT = 5; // horizontal: z: + <- -
    private float WORM_Y = 1; // horizontal: z: + <- -

    private GameObject[] eagles;
    private GameObject[] worms;

    // private GameObject[] fruits;
    private GameObject[] pebbles;

    private int EAGLE_INDEX = 0;
    private int PEBBLE_INDEX = 1;
    private int WORM_INDEX = 2;

    // private float FRUIT_LIMIT_LEFT = -10; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_RIGHT = -300; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_UP = 90; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_DOWN = 60; // horizontal: z: + <- -

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        // Check number of eagles. If there are more than its max, don't spawn more.
        eagles = GameObject.FindGameObjectsWithTag("Eagle");
        if (eagles.Length <= EAGLE_MAX_COUNT)
        {
            SpawnRandomEagle();
            Debug.Log("Number of eagles: " + eagles.Length);
        }

        // Check number of worms. If there are more than its max, don't spawn more.
        worms = GameObject.FindGameObjectsWithTag("Worm");
        if (worms.Length <= WORM_MAX_COUNT)
        {
            SpawnRandomWorm();
            Debug.Log("Number of worms: " + worms.Length);
        }

        // Check number of pebbles. If there are more than its max, don't spawn more.
        pebbles = GameObject.FindGameObjectsWithTag("Pebble");
        if (pebbles.Length <= PEBBLE_MAX_COUNT)
        {
            SpawnRandomPebble();
            Debug.Log("Number of pebbles: " + pebbles.Length);
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
        Instantiate(allPrefabs[PEBBLE_INDEX], spawnPos, allPrefabs[PEBBLE_INDEX].transform.rotation);
    }

    // void SpawnRandomPrefab()
    // {
    //     float x = 0;
    //     float y = 0;
    //     float z = 0;

        // 0: eagle, 1: pebble, 2: worm
        // int prefabIndex = Random.Range(0, allPrefabs.Length);

        // if (prefabIndex == 0) // eagle
        // {
        //     y = Random.Range(EAGLE_LIMIT_DOWN, EAGLE_LIMIT_UP);
        //     z = Random.Range(EAGLE_LIMIT_LEFT, EAGLE_LIMIT_RIGHT);
        // }

    //     if (prefabIndex == 1) // pebble
    //     {
    //         y = PEBBLE_Y;
    //         z = Random.Range(PEBBLE_LIMIT_LEFT, PEBBLE_LIMIT_RIGHT);
    //     }
    //     if (prefabIndex == 2) // worm
    //     {
    //         y = WORM_Y;
    //         z = Random.Range(WORM_LIMIT_LEFT, WORM_LIMIT_RIGHT);
    //     }

    //     //         if (prefabIndex == 1) // fruit
    //     // {
    //     //     y = Random.Range(FRUIT_LIMIT_DOWN, FRUIT_LIMIT_UP);
    //     //     z = Random.Range(FRUIT_LIMIT_LEFT, FRUIT_LIMIT_RIGHT);
    //     // }

    //     Vector3 spawnPos = new Vector3(x, y, z);

    //     Instantiate(allPrefabs[prefabIndex], spawnPos, allPrefabs[prefabIndex].transform.rotation);
    // }
}
