using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclesToSpawn;
    [SerializeField] private float spawnDelayTime = 0.1f;
    [SerializeField] private Transform obstacleContainer;
    [SerializeField] private Collider spawnArea;
    [SerializeField] private int maxObstacles;
    // private int maxObstacles;
    private int obstacleToSpawn;
    
    private LayerMask playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            Debug.Log("Obstacles inc!");
            StartCoroutine(SpawnAfterDelay());
        }
    }

    private IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < maxObstacles; i++)
        {
            obstacleToSpawn = ChoseObstacle();
            PlaceObstacle(obstacleToSpawn);
        }
    }

    private int ChoseObstacle() => Random.Range(0, obstaclesToSpawn.Count);

    private void PlaceObstacle(int numberToSpawn) =>
        Instantiate(obstaclesToSpawn[numberToSpawn], GetSpawnLocation(), Quaternion.identity, obstacleContainer);

    private Vector3 GetSpawnLocation()
    {
        Vector3 spawn = spawnArea.bounds.center;
        spawn.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        spawn.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
        return spawn;
    }

}
