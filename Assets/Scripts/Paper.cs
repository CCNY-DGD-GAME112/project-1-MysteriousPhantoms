using UnityEngine;

public class Paper : MonoBehaviour
{
    public float speed = 6f;
    private bool hasHitPlayer = false;

    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHitPlayer) return;

        if (other.CompareTag("Player"))
        {
            PlayerLives player = other.GetComponent<PlayerLives>();

            if (player != null)
                player.TakeDamage(1);

            hasHitPlayer = true;
            Destroy(gameObject);
        }
    }
}