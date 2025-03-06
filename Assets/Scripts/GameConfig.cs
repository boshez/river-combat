using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "River Raid/Game Configuration")]
public class GameConfig : ScriptableObject
{
    [Header("Player Settings")]
    public float playerMoveSpeed = 5f;
    public float playerFireRate = 0.5f;
    public int playerStartLives = 3;

    [Header("Enemy Settings")]
    public float enemySpawnRate = 2f;
    public float enemyMoveSpeed = 2f;
    public int enemyBaseScore = 100;

    [Header("Power-up Settings")]
    public float powerUpDuration = 5f;
    public float powerUpSpawnRate = 15f;
    public float speedBoostMultiplier = 1.5f;
    
    [Header("Game Difficulty")]
    public float difficultyIncreaseRate = 0.1f;
    public float maxDifficulty = 2f;
}
