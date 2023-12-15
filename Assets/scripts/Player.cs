using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private float attackRange = 5f;

    public healthBar healthBar;
    public Enemy enemy;
    public Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (IsPlayerInAttackRange())
        {
            TakeDamage(20);
        }
    }

    bool IsPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SethHealth(currentHealth);
    }
}
