using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject beachBall;
    public Transform firePoint;
    public float moveSpeed = 5f;

    public float leftBoundary = -7f;
    public float rightBoundary = 7f;

    void Update()
    {
        // Player Movement
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Stop player from leaving the screen, my damn boundary box is worthless
        if (transform.position.x < leftBoundary)
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);

        if (transform.position.x > rightBoundary)
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);

        // Shoot ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(beachBall, firePoint.position, Quaternion.identity);
        }
    }
}