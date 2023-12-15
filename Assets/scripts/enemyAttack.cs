//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class enemyAttack : MonoBehaviour
//{
//    public Transform player;
//    public float attackRange = 8f;
//    public Renderer ren;
//    public Material defaultMaterial;
//    public Material attackMaterial;
//    public int maxHealth = 100;
//    public int currentHealth;

//    private Enemy enemySript;//calling other script

//    private void Awake()
//    {
//        enemySript = GetComponent<Enemy>();
//    }

//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (Vector3.Distance(transform.position, player.position) <= attackRange)
//        {
//            ren.sharedMaterial = attackMaterial;
//            enemySript.badguy.SetDestination(player.position);

//        }
//        else
//        {
//            ren.sharedMaterial = defaultMaterial;
//            enemySript.NewLocation();
//        }


//    }

//    private void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//    }
//}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttack : MonoBehaviour
{
    public Transform player;
    public float attackRange = 5f;
    public float chaseRange = 10f;
    public int damageAmount = 10;
    public float attackCooldown = 1f;

    private NavMeshAgent agent;
    public healthBar playerHealthBar;
    private float nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHealthBar = player.GetComponent<healthBar>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 5f / attackCooldown;

        }
    }
}