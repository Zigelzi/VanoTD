using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject tower;

    bool isBuildable = true;
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
            tower = Instantiate(towerPrefab, transform.position, Quaternion.identity, transform);
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
            Destroy(tower);
            return true;
        }
        else
        {
            return false;
        }
    }
}
