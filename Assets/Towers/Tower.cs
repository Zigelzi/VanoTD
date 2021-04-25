using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildCost = 50;

    public GameObject Build(Tower tower, Tile tile)
    {
        GameObject builtTower;
        Bank bank = FindObjectOfType<Bank>();

        if (tile.IsBuildable && bank.CanAfford(buildCost))
        {
            builtTower = Instantiate(tower, tile.transform.position, tile.transform.rotation, tile.transform).gameObject;
            bank.Remove(buildCost);
            return builtTower;
        } else
        {
            builtTower = null;
            return builtTower;
        }
    }
}
