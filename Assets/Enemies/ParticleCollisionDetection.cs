using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionDetection : MonoBehaviour
{
    EnemyHealth enemyHealth;
    void Awake()
    {
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }
    private void OnParticleCollision(GameObject other)
    {
        enemyHealth.DetectParticleCollision(other);
    }
}
