using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent badguy;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 3f;
    public healthBar health;

    void Start()
    {
        NewLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, zPosition)) <= closeEnough)
        {
            NewLocation();
        }
    }

    public void TakeDamage(int damage)
    {
        health.currentHealth -= damage;

        health.SethHealth(health.currentHealth);
    }
    public void NewLocation()
    {

        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        badguy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
