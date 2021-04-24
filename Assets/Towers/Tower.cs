using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildCost = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Build(Tower tower, Tile tile)
    {
        GameObject builtTower;

        if (tile.IsBuildable)
        {
            builtTower = Instantiate(tower, tile.transform.position, tile.transform.rotation, tile.transform).gameObject;
            return builtTower;
        } else
        {
            builtTower = null;
            return builtTower;
        }
    }
}
