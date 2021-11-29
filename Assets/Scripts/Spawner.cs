using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private List<Vector3> spawnLocations;
    private int numberToSpawn = 1;
    private int limit = 20;
    private float spawnRate = 1.5f;
    private float spawnTimer;
    private int numberOfSpawnLocations = 8;
    private float minSpawnX = -18f;
    private float maxSpawnX = 10f;
    private float minSpawnZ = -17f;
    private float maxSpawnZ = 17f;

    private void Start()
    {
        SetSpawnLocations();
        spawnTimer = spawnRate;
    }

    private void Update()
    {
        if (parentObject.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, spawnLocations[Random.Range(0, numberOfSpawnLocations)], Quaternion.identity);
                }
                spawnTimer = spawnRate;
            }
        }
    }

    private void SetSpawnLocations()
    {
        for (int i = 0; i < numberOfSpawnLocations; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), 0.5f, Random.Range(minSpawnZ, maxSpawnZ));
            spawnLocations.Add(spawnLocation);
        }
    }
}