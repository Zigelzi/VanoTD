using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 100;
    int currentBalance;
    // Start is called before the first frame update
    void Start()
    {
        currentBalance = startingBalance;
    }

    public void Add(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Remove(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }

    public bool CanAfford(int buildCost)
    {
        int balanceAfterBuilding = currentBalance - buildCost;
        if (balanceAfterBuilding >= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
