using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject tower;
    [SerializeField] bool isBuildable = true;
    public bool IsBuildable { get { return isBuildable; } }

    GridManager gridManager;
    Pathfinder pathFinder;
    Vector2Int tileCoordinates = new Vector2Int();

    // Start is called before the first frame update
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            tileCoordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isBuildable)
            {
                gridManager.BlockNode(tileCoordinates);
            }
        }
    }

    // OnMouseDown registers only left click
    void OnMouseDown()
    {
        PlaceTower();   
    }

    void OnMouseOver()
    {
        // Register right click on mouse hover
        DestroyTower();
    }

    bool PlaceTower()
    {
        if (CanBuild())
        {
            tower = towerPrefab.Build(towerPrefab, this);
            isBuildable = false;
            gridManager.BlockNode(tileCoordinates);

            return true;
        } else
        {
            return false;
        }
    }

    bool CanBuild()
    {
        if (Input.GetMouseButtonDown(0) &&
            isBuildable &&
            towerPrefab != null &&
            gridManager.GetNode(tileCoordinates).isWalkable &&
            !pathFinder.WillBlockPath(tileCoordinates)
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool DestroyTower()
    {
        if (CanDestroy())
        {
            Destroy(tower);
            tower = null;
            isBuildable = true;
            gridManager.UnblockNode(tileCoordinates);

            return true;
        } else
        {
            return false;
        }
    }

    bool CanDestroy()
    {
        if (Input.GetMouseButtonDown(1) && tower != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
