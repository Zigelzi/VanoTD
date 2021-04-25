using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State { Alive, Transcending, Defeated }
    public State GameState { get { return gameState; } }

    [SerializeField] int maxLives = 10;
    [SerializeField] int currentLives;

    int restartDelay = 2;
    State gameState;
    Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives <= 0)
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        gameState = State.Defeated;
        Invoke("RestartGame", restartDelay);
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LoseLife()
    {
        currentLives -= 1;
    }
}
