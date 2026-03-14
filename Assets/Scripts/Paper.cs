using UnityEngine;

public class Paper : MonoBehaviour
{
    public float speed = 6f;
    private bool hasHitPlayer = false; // track if this paper already hit

    void Update()
    {
        // Move downward
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        // Destroy if off-screen
        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only act once
        if (hasHitPlayer) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLives player = collision.gameObject.GetComponent<PlayerLives>();
            if (player != null)
                player.TakeDamage(1);

            hasHitPlayer = true; // mark as hit
            Destroy(gameObject); // destroy paper
        }
    }
}