using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int killReward = 20;
    EnemyMovement movement;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        gameObject.SetActive(false);
        movement.ReturnToStart();
        bank.Add(killReward);
    }
}
