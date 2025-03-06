using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public int scoreValue = 100;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (other.CompareTag("Bullet"))
            {
                HandleEnemyDestruction(other.gameObject);
            }
            else if (other.CompareTag("Player"))
            {
                HandlePlayerCollision(other.gameObject);
            }
        }
    }

    void HandleEnemyDestruction(GameObject bullet)
    {
        Destroy(bullet);
        Destroy(gameObject);
        if (gameManager != null)
        {
            gameManager.AddScore(scoreValue);
        }
    }

    void HandlePlayerCollision(GameObject player)
    {
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
