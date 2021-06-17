using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField][Range(0, 50f)] float movementSpeed = 10f;

    GameManager gameManager;
    GridManager gridManager;
    Pathfinder pathFinder;
    List<Node> path = new List<Node>();
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {
        FindPath();
        if (path.Count > 0)
        {
            StartCoroutine(FollowPath());
        }
        
    }

    void FindPath()
    {
        path.Clear();

        path = pathFinder.GetNewPath();
    }

    

    IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startingPosition = transform.position;

            Vector2Int nextNodeCoordinates = path[i].coordinates;
            Vector3 nextNodePosition = gridManager.GetPositionFromCoordinates(nextNodeCoordinates);
            float travelPercent = 0f;

            transform.LookAt(nextNodePosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startingPosition, nextNodePosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        // If destination (last node) is reached, disable the GameObject and remove life from player
        gameObject.SetActive(false);
        ReturnToStart();
        gameManager.LoseLife();
    }
    public void ReturnToStart()
    {
        Vector2Int startCoordinates = pathFinder.StartCoordinates;
        transform.position = gridManager.GetPositionFromCoordinates(startCoordinates);
    }
}
