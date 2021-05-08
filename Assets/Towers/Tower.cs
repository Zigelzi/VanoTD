using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [SerializeField] int buildCost = 50;

    public GameObject Build(Tower tower, Tile tile)
    {   
        GameObject builtTower = null;
        Bank bank = FindObjectOfType<Bank>();

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return builtTower;
        }

        if (tile.IsBuildable && bank.CanAfford(buildCost))
        {
            builtTower = Instantiate(tower, tile.transform.position, tile.transform.rotation, tile.transform).gameObject;
            bank.Remove(buildCost);
            return builtTower;
        } else
        {
            return builtTower;
        }
    }
}
