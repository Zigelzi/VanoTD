using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum State { Alive, Transcending, Defeated }
    public State GameState { get { return gameState; } }

    [SerializeField] int maxLives = 10;
    [SerializeField] int currentLives;

    [SerializeField] State gameState;
    Bank bank;
    TextMeshProUGUI lifeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        lifeDisplay = GameObject.FindGameObjectWithTag("UI_LivesDisplay").GetComponent<TextMeshProUGUI>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives <= 0)
        {
            LoseGame();
        }
    }

    void StartGame()
    {
        gameState = State.Alive;
        currentLives = maxLives;
        lifeDisplay.text = $"Lives: {currentLives}";
    }

    void LoseGame()
    {
        gameState = State.Defeated;
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LoseLife()
    {
        currentLives -= 1;
        UpdateLifeDisplay();
    }

    void UpdateLifeDisplay()
    {
        lifeDisplay.text = $"Lives: {currentLives}";
    }
}
