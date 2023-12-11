using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance for easy access from other scripts
    public static GameManager Instance;

    public Transform player;
    public int health;
    public bool isGameOver;
    public GameObject gameOverPanel;
    public float killScore; // Renamed killscore to killScore for consistency

    // Ensures only one instance of GameManager exists
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject); // Destroy duplicate GameManager instances
        }
    }

    // Check health conditions and manage game state
    void Update()
    {
        CheckHealth(); // Abstracted health check for clarity
    }

    // Checks and handles game over conditions
    void CheckHealth()
    {
        if (health <= 0)
        {
            GameOver(true);
        }
        else if (health > 5)
        {
            health = 5; // Cap health at 5
        }
    }

    // Triggers game over and displays the game over panel
    public void GameOver(bool isTrue)
    {
        isGameOver = isTrue;
        gameOverPanel.SetActive(true);
        // Any additional game over logic can be added here
    }
}
