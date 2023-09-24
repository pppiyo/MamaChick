using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] allPrefabs; // 0: eagle, 1: fruit, 2: pebble, 3: worm

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
    private float FRUIT_LIMIT_LEFT = -10; // horizontal: z: + <- -
    private float FRUIT_LIMIT_RIGHT = -300; // horizontal: z: + <- -
    private float FRUIT_LIMIT_UP = 90; // horizontal: z: + <- -
    private float FRUIT_LIMIT_DOWN = 60; // horizontal: z: + <- -

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", 2, 2);
    }

    // Update is called once per frame
    void Update() { }

    void SpawnRandomPrefab()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        // 0: eagle, 1: fruit, 2: pebble, 3: worm
        int prefabIndex = Random.Range(0, allPrefabs.Length);

        if (prefabIndex == 0) // eagle
        {
            y = Random.Range(EAGLE_LIMIT_DOWN, EAGLE_LIMIT_UP);
            z = Random.Range(EAGLE_LIMIT_LEFT, EAGLE_LIMIT_RIGHT);
        }
        if (prefabIndex == 1) // fruit
        {
            y = Random.Range(FRUIT_LIMIT_DOWN, FRUIT_LIMIT_UP);
            z = Random.Range(FRUIT_LIMIT_LEFT, FRUIT_LIMIT_RIGHT);
        }
        if (prefabIndex == 2) // pebble
        {
            y = PEBBLE_Y;
            z = Random.Range(PEBBLE_LIMIT_LEFT, PEBBLE_LIMIT_RIGHT);
        }
        if (prefabIndex == 3) // worm
        {
            y = WORM_Y;
            z = Random.Range(WORM_LIMIT_LEFT, WORM_LIMIT_RIGHT);
        }

        Vector3 spawnPos = new Vector3(x, y, z);

        Instantiate(allPrefabs[prefabIndex], spawnPos, allPrefabs[prefabIndex].transform.rotation);
    }
}
