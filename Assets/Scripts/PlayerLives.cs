using UnityEngine;
using UnityEngine.UI;
// I watched a video and done extensive research for this
public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;

    public void TakeDamage(int damage)
    {
        lives -= damage;

        // update life icons
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }

        if (lives <= 0)
        {
            GameManager.instance.LoseGame();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}