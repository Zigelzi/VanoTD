using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    Enemy enemy;
    HealthBar healthBar;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        healthBar = transform.GetComponentInChildren<HealthBar>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        healthBar = transform.GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
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
            healthBar.UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            enemy.Die();
        }
    }

    

    
}
