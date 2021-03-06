using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    void Awake()
    {
        CreateGrid();    
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                Node currentNode = new Node(coordinates, true);
                grid.Add(coordinates, currentNode);
            }
        }
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        } else
        {
            return null;
        }
    }

    public bool BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
            return true;
        } else
        {
            return false;
        }
    }

    public bool UnblockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> node in grid)
        {
            node.Value.connectedTo = null;
            node.Value.isExplored = false;
            node.Value.isPath = false;
        }
    }

    // Convert world position into coordinates
    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    // Convert coordinate into world position
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = Mathf.RoundToInt(coordinates.x * unityGridSize);
        position.z = Mathf.RoundToInt(coordinates.y * unityGridSize);

        return position;
    }
}
