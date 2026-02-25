using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // singleton I think
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float roundTime = 30f;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateTimerText();
    }

    private void Update()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;
            UpdateTimerText();

            if (roundTime <= 0)
            {
                roundTime = 0;
                GameOver();
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(roundTime / 60);
        int seconds = Mathf.FloorToInt(roundTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Optionally trigger UI/game over screen here
    }
}