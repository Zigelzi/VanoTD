using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject tower;
    [SerializeField] bool isBuildable = true;
    public bool IsBuildable { get { return isBuildable; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            return true;
        } else
        {
            return false;
        }
    }

    bool CanBuild()
    {
        if (Input.GetMouseButtonDown(0) && isBuildable && towerPrefab != null)
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
