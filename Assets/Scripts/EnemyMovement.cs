using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy enemy if it leaves screen
        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}