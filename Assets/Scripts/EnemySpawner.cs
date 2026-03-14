using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Assign your Enemy prefab
    public float spawnInterval = 1.5f;  // Seconds between spawns
    public float xMin = -7f;            // Left screen edge
    public float xMax = 7f;             // Right screen edge
    public float ySpawn = 6f;           // Top of screen

    void Start()
    {
        // Spawn first enemy after 1 second, repeat every spawnInterval
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