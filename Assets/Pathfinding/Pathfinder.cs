using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.down, Vector2Int.left, Vector2Int.up };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    // Start is called before the first frame update
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    private void Start()
    {
        startNode = grid[startCoordinates];
        destinationNode = grid[destinationCoordinates];
        BreathFirstSearch();
        BuildPath();
    }

    void ExploreNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = node.coordinates + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                neighbors.Add(grid[neighborCoordinates]);

            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) &&  neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreathFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startNode.coordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            if (currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false; 
            }
            ExploreNeighbors(currentSearchNode);
            
        } 

    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();

        // Start creating path from destination
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            // Continue traversing the connected nodes until there's no remaining nodes, so we're at the beginning
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();
        return path;
    }

}
