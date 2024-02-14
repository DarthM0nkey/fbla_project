using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point where the bullet is spawned
    public float fireRate = 2f; // Rate of fire in bullets per second

    private Transform player; // Reference to the player's transform
    private float nextFireTime; // Time of the next allowed shot

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found in the scene. Make sure you have a player GameObject tagged as Player.");
        }
    }

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            // Calculate the time of the next allowed shot
            nextFireTime = Time.time + 1f / fireRate;

            // Call a method to handle firing
            Fire();
        }
    }

    void Fire()
    {
        // Check if the bullet prefab and fire point are set
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate a bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - firePoint.position).normalized;

            // Set the bullet's velocity to the direction multiplied by a speed value
            bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // Adjust the speed as needed
        }
    }
}

