using UnityEngine;

public class BeachBall : MonoBehaviour
{
    public float moveSpeed = 8f;
    public ParticleSystem particledie;

    void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.instance.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(Instantiate(particledie.gameObject, transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }
    }
}