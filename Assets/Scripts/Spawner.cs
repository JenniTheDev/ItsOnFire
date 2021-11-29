using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform ballContainer;
    private int numberToSpawn = 1;
    private int spawnLimit = 20;
    private float spawnRate = 1.5f;
    private float spawnTimer;
    [SerializeField] private Collider playingArea;

    private void Start()
    {
        spawnTimer = spawnRate;
    }

    private void Update()
    {
        if (ballContainer.childCount < spawnLimit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, GetSpawnLocation(), Quaternion.identity, ballContainer);
                }
                spawnTimer = spawnRate;
            }
        }
    }

    private Vector3 GetSpawnLocation()
    {
        Vector3 spawn = playingArea.bounds.center;
        spawn.x = Random.Range(playingArea.bounds.min.x, playingArea.bounds.max.x);
        spawn.z = Random.Range(playingArea.bounds.min.z, playingArea.bounds.max.z);
        return spawn;
    }
}