using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject paperPrefab;  
    public Transform firePoint;
    public float shootDelay = 2f;

    void Start()
    {
        InvokeRepeating("Shoot", 1f, shootDelay);
    }

    void Shoot()
    {
        // Spawn paper at firePoint
        Instantiate(paperPrefab, firePoint.position, Quaternion.identity);
    }
}