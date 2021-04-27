using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 10)] int poolSize = 5;
    [SerializeField] [Range(0.5f, 30f)] float spawnInterval = 3f;
    [SerializeField] bool spawningEnabled = true;

    GameObject[] objectPool;
    GameManager gameManager;
    Vector3 spawnPosition;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetSpawnPosition();
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpawnPosition()
    {
        // Update this to use the grid manager when it's implemented
        spawnPosition = new Vector3(50, 0, 40);
    }

    void PopulatePool()
    {
        objectPool = new GameObject[poolSize];
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i] = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
            objectPool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (spawningEnabled && gameManager.GameState == GameManager.State.Alive)
        {
            for (int i = 0; i < objectPool.Length; i++)
            {
                SpawnEnemy(i);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    void SpawnEnemy(int poolPosition)
    {
        if (enemyPrefab != null && objectPool.Length > 0)
        {
            objectPool[poolPosition].SetActive(true);
        }
    }
}
