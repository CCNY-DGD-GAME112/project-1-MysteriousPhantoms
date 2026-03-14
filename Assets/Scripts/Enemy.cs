using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject paperPrefab;
    public Transform firePoint;
    public float shootDelay = 2f;

    void Start()
    {
        // Reset rotation to avoid weird movement
        transform.rotation = Quaternion.identity;

        // Stop Rigidbody2D if exists
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // Start shooting
        if (paperPrefab != null && firePoint != null)
            InvokeRepeating("Shoot", 1f, shootDelay);
    }

    void Update()
    {
        // Move downward
        transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void Shoot()
    {
        Instantiate(paperPrefab, firePoint.position, Quaternion.identity);
    }
}