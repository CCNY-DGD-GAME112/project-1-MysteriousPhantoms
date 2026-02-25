using UnityEngine;

public class BeachBall : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        // move straight up in world space
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
