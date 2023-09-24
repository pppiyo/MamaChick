using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int MAX_APPLES = 10;
    public GameObject[] applePrefabs;

    private float spawnLimitZLeft = -10;
    private float spawnLimitZRight = -300;
    private float spawnPosY = 60;

    private float startDelay = 0.1f;
    private float spawnIntervalDefault = 1.0f;

    // private float spawnIntervalLo = 1.0f;
    // private float spawnIntervalHi = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnRandomApple", startDelay, spawnIntervalDefault);
        // InvokeRepeating("SpawnRandomApple", startDelay, Random.Range(spawnIntervalLo, spawnIntervalHi));
    }

    // Spawn random ball at random x position at top of play area
    // void SpawnRandomApple()
    // {
    //     applePrefabs = new GameObject[MAX_APPLES];
    //     // Generate random ball index and random spawn position
    //     Vector3 spawnPos = new Vector3(
    //         0,
    //         spawnPosY,
    //         Random.Range(spawnLimitZLeft, spawnLimitZRight)
    //     );

    //     int appleIndex = Random.Range(0, applePrefabs.Length);

    //     // instantiate ball at random spawn location
    //     Instantiate(
    //         applePrefabs[appleIndex],
    //         spawnPos,
    //         applePrefabs[appleIndex].transform.rotation
    //     );
    // }
}
