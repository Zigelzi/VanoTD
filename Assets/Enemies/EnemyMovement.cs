using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0, 50f)] float movementSpeed = 10f;

    GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        Transform pathParent = GameObject.FindGameObjectWithTag("Path").transform;
        foreach (Transform child in pathParent)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void OnEnable()
    {
        if (path.Count > 0)
        {
            StartCoroutine(FollowPath());
        }
        
    }

    IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startingPosition = transform.position;
            Vector3 destinationPosition = path[i].transform.position;
            float travelPercent = 0f;

            transform.LookAt(destinationPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startingPosition, destinationPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        // If destination (last node) is reached, disable the GameObject and remove life from player
        gameObject.SetActive(false);
        ResetPosition();
        gameManager.LoseLife();
    }

    public void ResetPosition()
    {
        if (path.Count > 0)
        {
            transform.position = path[0].transform.position;
        }
        
    }
}
