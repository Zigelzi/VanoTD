using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 100;
    [SerializeField] int currentBalance;

    TextMeshProUGUI goldDisplay;

    // Start is called before the first frame update
    void Start()
    {
        goldDisplay = GameObject.FindGameObjectWithTag("UI_GoldDisplay").GetComponent<TextMeshProUGUI>();
        InitialiseBalance();
    }

    void InitialiseBalance()
    {
        currentBalance = startingBalance;
        goldDisplay.text = $"Gold: {currentBalance}";
    }

    public void Add(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceDisplay();
    }

    public void Remove(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalanceDisplay();
    }

    void UpdateBalanceDisplay()
    {
        goldDisplay.text = $"Gold: {currentBalance}";
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
