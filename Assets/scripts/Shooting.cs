using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gunTransform;
    public LayerMask enemyLayer;
    public float shootingRange = 50f;
    public int damagePerShot = 20;
    public int maxAmmo = 10;
    public float reloadTime = 2f;

    private int currentAmmo;
    private bool isReloading = false;
    private healthBar healthBar;

    void Start()
    {
        currentAmmo = maxAmmo;
        healthBar = GetComponent<healthBar>();
    }

    void Update()
    {
        if (isReloading)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(gunTransform.position, gunTransform.forward, out hit, shootingRange, enemyLayer))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damagePerShot);
                }
            }

            currentAmmo--;

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}