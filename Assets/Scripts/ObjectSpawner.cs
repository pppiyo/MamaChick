using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner instance;

    public GameObject objectToSpawn; // 要生成的物体
    public Transform wallTransform;  // 墙的Transform
    public float spawnInterval = 5f; // 生成物体的间隔时间
    public float spawnRadius = 400f;  // 生成物体的半径范围

    public int maxObjectCount = 10;  // 最大物体数量
    private int currentObjectCount = 0;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (currentObjectCount < maxObjectCount && Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        // 随机生成位置的X坐标在墙的左侧
        float randomX = Random.Range(wallTransform.position.x - spawnRadius, wallTransform.position.x);

        // 生成物体的位置
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y - 20f, transform.position.z);

        // 实例化物体
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        currentObjectCount++;
    }

    public void ObjectDestroyed()
    {
        currentObjectCount--;
    }
}
