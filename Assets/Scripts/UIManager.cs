using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;
    public GameObject powerUpIndicator;
    
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameOverPanel.SetActive(false);
        UpdateHighScore();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High Score: {highScore}";
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowPowerUpIndicator(string powerUpType, float duration)
    {
        powerUpIndicator.SetActive(true);
        TextMeshProUGUI indicatorText = powerUpIndicator.GetComponentInChildren<TextMeshProUGUI>();
        indicatorText.text = powerUpType;
        Invoke("HidePowerUpIndicator", duration);
    }

    private void HidePowerUpIndicator()
    {
        powerUpIndicator.SetActive(false);
    }
}
