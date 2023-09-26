using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.RegularExpressions;

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
    private int FRUIT_1_INDEX = 3;
    private int FRUIT_2_INDEX = 4;
    private int FRUIT_3_INDEX = 5;
    private int FRUIT_4_INDEX = 6;
    private int FRUIT_5_INDEX = 7;
    private int FRUIT_6_INDEX = 8;
    private int FRUIT_7_INDEX = 9;
    private int FRUIT_8_INDEX = 10;
    private int FRUIT_9_INDEX = 11;
    private int FRUIT_10_INDEX = 12;
    private int FRUIT_11_INDEX = 13;
    private int FRUIT_12_INDEX = 14;
    private int FRUIT_13_INDEX = 15;

    private GameObject[] fruit1;
    private GameObject[] fruit2;
    private GameObject[] fruit3;
    private GameObject[] fruit4;
    private GameObject[] fruit5;
    private GameObject[] fruit6;
    private GameObject[] fruit7;
    private GameObject[] fruit8;
    private GameObject[] fruit9;
    private GameObject[] fruit10;
    private GameObject[] fruit11;
    private GameObject[] fruit12;
    private GameObject[] fruit13;

    // public string namePattern;

    // private float FRUIT_LIMIT_LEFT = -10; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_RIGHT = -300; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_UP = 90; // horizontal: z: + <- -
    // private float FRUIT_LIMIT_DOWN = 60; // horizontal: z: + <- -

    // Start is called before the first frame update
    void Start() { }

    // void SpawnPrefab(string prefabName)
    // {
    //     // Load the prefab by its name from the "Resources" folder
    //     GameObject prefab = Resources.Load<GameObject>(prefabName);
    //     Debug.Log(prefab == null ? "Prefab is null" : "Prefab is not null");
    //     // Instantiate the prefab at the specified position
    //     Instantiate(prefab, transform.position, Quaternion.identity);
    // }

    // Update is called once per frame
    void Update()
    {
        fruit1 = GameObject.FindGameObjectsWithTag("Fruit1");
        if (fruit1.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_1_INDEX], transform.position, Quaternion.identity);
        }

        fruit2 = GameObject.FindGameObjectsWithTag("Fruit2");
        if (fruit2.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_2_INDEX], transform.position, Quaternion.identity);
        }

        fruit3 = GameObject.FindGameObjectsWithTag("Fruit3");
        if (fruit3.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_3_INDEX], transform.position, Quaternion.identity);
        }

        fruit4 = GameObject.FindGameObjectsWithTag("Fruit4");
        if (fruit4.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_4_INDEX], transform.position, Quaternion.identity);
        }

        fruit5 = GameObject.FindGameObjectsWithTag("Fruit5");
        if (fruit5.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_5_INDEX], transform.position, Quaternion.identity);
        }

        fruit6 = GameObject.FindGameObjectsWithTag("Fruit6");
        if (fruit6.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_6_INDEX], transform.position, Quaternion.identity);
        }

        fruit7 = GameObject.FindGameObjectsWithTag("Fruit7");
        if (fruit7.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_7_INDEX], transform.position, Quaternion.identity);
        }

        fruit8 = GameObject.FindGameObjectsWithTag("Fruit8");
        if (fruit8.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_8_INDEX], transform.position, Quaternion.identity);
        }

        fruit9 = GameObject.FindGameObjectsWithTag("Fruit9");
        if (fruit9.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_9_INDEX], transform.position, Quaternion.identity);
        }

        fruit10 = GameObject.FindGameObjectsWithTag("Fruit10");
        if (fruit10.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_10_INDEX], transform.position, Quaternion.identity);
        }

        fruit11 = GameObject.FindGameObjectsWithTag("Fruit11");
        if (fruit11.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_11_INDEX], transform.position, Quaternion.identity);
        }

        fruit12 = GameObject.FindGameObjectsWithTag("Fruit12");
        if (fruit12.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_12_INDEX], transform.position, Quaternion.identity);
        }

        fruit13 = GameObject.FindGameObjectsWithTag("Fruit13");
        if (fruit13.Length <= 1)
        {
            Instantiate(allPrefabs[FRUIT_13_INDEX], transform.position, Quaternion.identity);
        }

        // Check number of eagles. If there are more than its max, don't spawn more.
        eagles = GameObject.FindGameObjectsWithTag("Eagle");
        if (eagles.Length <= EAGLE_MAX_COUNT)
        {
            SpawnRandomEagle();
            // Debug.Log("Number of eagles: " + eagles.Length);
        }

        // Check number of worms. If there are more than its max, don't spawn more.
        worms = GameObject.FindGameObjectsWithTag("Worm");
        if (worms.Length <= WORM_MAX_COUNT)
        {
            SpawnRandomWorm();
            // Debug.Log("Number of worms: " + worms.Length);
        }

        // Check number of pebbles. If there are more than its max, don't spawn more.
        pebbles = GameObject.FindGameObjectsWithTag("Pebble");
        if (pebbles.Length <= PEBBLE_MAX_COUNT)
        {
            SpawnRandomPebble();
            // Debug.Log("Number of pebbles: " + pebbles.Length);
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
