using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Singleton instance

    public int totalEnemies; // Total number of enemies in the scene
    private int enemiesRemaining; // Number of enemies remaining

    private void Awake()
    {
        // Set up the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize enemiesRemaining to totalEnemies
        enemiesRemaining = totalEnemies;
    }

    public void EnemyKilled()
    {
        enemiesRemaining--;

        // Check if all enemies are killed
        if (enemiesRemaining <= 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene (you may replace "NextSceneName" with your actual scene name)
        SceneManager.LoadScene("NextSceneName");
    }
}
