using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject paperPrefab;      // Assign Paper prefab
    public Transform firePoint;         // Empty child object slightly below enemy
    public float shootDelay = 2f;       // Time between shots

    void Start()
    {
        InvokeRepeating("Shoot", 1f, shootDelay);
    }

    void Shoot()
    {
        // Spawn paper at firePoint, not parented to enemy
        Instantiate(paperPrefab, firePoint.position, Quaternion.identity);
    }
}