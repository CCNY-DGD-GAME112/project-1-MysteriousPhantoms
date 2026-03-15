using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int scoreToWin = 250;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject loseScreen;
    public GameObject winScreen;

    public float roundTime = 30f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;

            timerText.text = "Time: " + Mathf.FloorToInt(roundTime);

            if (score >= scoreToWin)
            {
                WinGame();
            }

            if (roundTime <= 0)
            {
                LoseGame();
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

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
