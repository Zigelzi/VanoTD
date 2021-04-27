using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] waves;
    //[SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 10)] int enemyCount = 5;
    [SerializeField] [Range(0.5f, 30f)] float spawnInterval = 3f;

    GameObject[] objectPool;
    GameManager gameManager;
    Vector3 spawnPosition;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetSpawnPosition();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Check how many waves there is
        // Populate object pool with first wave prefabs
        // Spawn wave
        // Wait until no enemies are present anymore
        // Wait building period
        // Populate object pool with next wave prefabs
        // Spawn next wave
        // Spawn waves until there's no more waves defined
        // Player wins the game
        StartCoroutine(SpawnWaves());

    }

    void SetSpawnPosition()
    {
        // Update this to use the grid manager when it's implemented
        spawnPosition = new Vector3(50, 0, 40);
    }

    IEnumerator SpawnWaves()
    {
        foreach (GameObject wave in waves)
        {
            
            PopulatePool(wave);
            yield return StartCoroutine(SpawnSingleWave());
        }
    }

    void PopulatePool(GameObject wavePrefab)
    {

        objectPool = new GameObject[enemyCount];
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i] = Instantiate(wavePrefab, spawnPosition, Quaternion.identity, transform);
            objectPool[i].SetActive(false);
        }
    }

    IEnumerator SpawnSingleWave()
    {
        bool spawningEnabled = true;
        
        while (spawningEnabled && gameManager.GameState == GameManager.State.Alive)
        {
            for (int i = 0; i < objectPool.Length; i++)
            {
                SpawnEnemy(i);
                yield return new WaitForSeconds(spawnInterval);
            }
            spawningEnabled = false;
        }
        
    }

    void SpawnEnemy(int poolPosition)
    {
        if (waves != null && objectPool.Length > 0)
        {
            objectPool[poolPosition].SetActive(true);
        }
    }
}
