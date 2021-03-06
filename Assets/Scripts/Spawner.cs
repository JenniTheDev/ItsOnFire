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
    private float spawnDelayTimer;
    private float drawTime = 4f;
    private Vector3 center;

    // private float drawTime = 1;
    [SerializeField] private Collider playingArea;

    private void Start()
    {
        center = new Vector3(0, 1, 0);
        spawnDelayTimer = spawnRate;
    }

    private void Update()
    {
        CheckAndSpawnBalls();
    }

    private Vector3 GetSpawnLocation()
    {
        Vector3 spawn = playingArea.bounds.center;
        spawn.x = Random.Range(playingArea.bounds.min.x, playingArea.bounds.max.x);
        spawn.z = Random.Range(playingArea.bounds.min.z, playingArea.bounds.max.z);

        Debug.DrawLine(Vector3.up, spawn, Color.magenta, drawTime);
        return spawn;
    }

    private void CheckAndSpawnBalls()
    {
        if (ballContainer.childCount < spawnLimit)
        {
            spawnDelayTimer -= Time.deltaTime;
            if (spawnDelayTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, GetSpawnLocation(), Quaternion.identity, ballContainer);
                }
                spawnDelayTimer = spawnRate;
            }
        }
    }
}