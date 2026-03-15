using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;  // Seconds between spawns
    public float xMin = -7f;            // Left screen
    public float xMax = 7f;             // Right screen
    public float ySpawn = 6f;           // Top screen

    void Start()
    {
        // spawnInterval is the time between the spawning of entities
        // InvokeRepeating calls a method repeatedly at a fixed time interval
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Random X position
        float x = Random.Range(xMin, xMax);
        Vector3 spawnPos = new Vector3(x, ySpawn, 0);

        // Create enemy
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}