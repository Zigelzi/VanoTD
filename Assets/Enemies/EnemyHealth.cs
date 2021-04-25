using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
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
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);

    }
}
