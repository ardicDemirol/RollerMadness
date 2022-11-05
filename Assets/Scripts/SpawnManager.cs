using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] private Transform[] spawnPositions;

    private float nextSpawnTime = 0f;


    void Start()
    {
        spawnPositions[0].gameObject.name = "Test";
    }

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime += spawnTime;
            //Instantiate(coinPrefab,transform.position,transform.rotation);
            SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            print("spawn");
        }
    }

    void SpawnObject(GameObject objectToSpawn,Transform newPosition)
    {
        Instantiate(objectToSpawn, newPosition.position, newPosition.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0, objects.Length);
    }
}
