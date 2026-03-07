using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject beachBall;  // drag the prefab here
    public Transform firePoint;   // drag FirePoint here

    void Update()
    {
        // Move Left
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * 5f * Time.deltaTime;

        // Move Right
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * 5f * Time.deltaTime;

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(beachBall, firePoint.position, Quaternion.identity);
        }
    }
}