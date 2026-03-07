using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private int direction = 1; // 1 = right, -1 = left
    
    void Update()
    {
        // Move left or right
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            // Turn around
            direction *= -1;

            // Go down a little
            transform.position += Vector3.down * 1f;
        }
    }
}