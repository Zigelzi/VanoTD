using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void DetectParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            ProcessHit(20);
        }
    }

    void ProcessHit(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            enemy.Die();
        }
    }

    

    
}
