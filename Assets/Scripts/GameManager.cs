using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score & Timer")]
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float roundTime = 30f;
    public TextMeshProUGUI timerText;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    [Header("Win UI")]
    public GameObject winPanel;
    public int scoreToWin = 50;

    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateTimerText();

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver) return;

        // Countdown timer
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
        if (isGameOver) return;

        score += amount;
        UpdateScoreText();

        // Check Win condition
        if (score >= scoreToWin)
        {
            WinGame();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(roundTime / 60);
            int seconds = Mathf.FloorToInt(roundTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("Game Over!");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        StopAllGameplay();
    }

    void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("You Win!");

        if (winPanel != null)
            winPanel.SetActive(true);

        StopAllGameplay();
    }

    private void StopAllGameplay()
    {
        // Stop all spawners
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (var spawner in spawners)
            spawner.enabled = false;

        // Stop all enemies
        EnemyShoot[] enemies = FindObjectsOfType<EnemyShoot>();
        foreach (var enemy in enemies)
            enemy.enabled = false;

        // Stop player
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.enabled = false;
    }
}