using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;

    // Track if damage was already applied in this frame to prevent double hits, I had to research this script.
    private bool tookDamageThisFrame = false;

    private void Update()
    {
        // Reset flag each frame
        tookDamageThisFrame = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tookDamageThisFrame) return;

        if (other.CompareTag("Enemy") || other.CompareTag("Paper"))
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        if (tookDamageThisFrame) return;

        lives -= amount;
        tookDamageThisFrame = true;

        // Update UI
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }

        // Check Game Over
        if (lives <= 0)
        {
            lives = 0;
            GameManager.instance.GameOver();
        }
    }
}