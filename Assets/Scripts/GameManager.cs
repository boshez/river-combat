using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public UIManager uiManager;
    public float gameSpeed = 1f;
    
    private int score;
    private bool isGameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        isGameOver = false;
        UpdateScore();
    }

    public void AddScore(int points)
    {
        if (isGameOver) return;
        
        score += points;
        UpdateScore();
        
        // Update high score if necessary
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            uiManager.UpdateHighScore();
        }
    }

    private void UpdateScore()
    {
        if (uiManager != null)
        {
            uiManager.UpdateScore(score);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        
        isGameOver = true;
        uiManager.ShowGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
