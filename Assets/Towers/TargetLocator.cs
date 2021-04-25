using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Display target for debugging purposes
    [SerializeField] GameObject target;
    [SerializeField] [Range(0, 60f)] float towerRange = 20f;

    [SerializeField] Transform targetPosition;

    Transform weapon;
    ParticleSystem projectile;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetWeapon();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameState == GameManager.State.Alive)
        {
            AimWeapon();
        }
    }

    Transform GetWeapon()
    {
        Transform weapon = null;
        foreach (Transform child in transform)
        {
            if (child.tag == "Tower_Weapon")
            {
                weapon = child;
                projectile = GetProjectile(weapon);
            }
        }
        return weapon;
    }

    ParticleSystem GetProjectile(Transform weapon)
    {
        if (weapon == null) { return null; }
        ParticleSystem projectile = weapon.GetComponentInChildren<ParticleSystem>();
        return projectile;
    }

    void AimWeapon()
    {
        if (target == null || target.activeSelf == false)
        {
            target = FindTarget();
        } else
        {
            float closesEnemyDistance = Vector3.Distance(transform.position, target.transform.position);
            weapon.LookAt(target.transform);
            if (closesEnemyDistance < towerRange)
            {
                Attack(true);
            } else
            {
                Attack(false);
                target = FindTarget();
            }
        }
    }

    GameObject FindTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length > 0)
        {
            GameObject closestEnemy = enemies[0].gameObject;
            Vector3 towerPosition = transform.position;
            float closestEnemyDistance = Vector3.Distance(towerPosition, closestEnemy.transform.position);

            foreach (Enemy enemy in enemies)
            {
                float distanceFromTower = Vector3.Distance(towerPosition, enemy.transform.position);

                if (distanceFromTower < closestEnemyDistance)
                {
                    closestEnemy = enemy.gameObject;
                }
            }

            return closestEnemy;

        } else
        {
            return null;
        }
    }

    void Attack(bool isShooting) {
        ParticleSystem.EmissionModule emissionModule = projectile.emission;
        emissionModule.enabled = isShooting;
    }
}
