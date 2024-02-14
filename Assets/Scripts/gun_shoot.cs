using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform barrelTransform;
    public float projectileSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your desired input
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile prefab at the barrel position and rotation
        GameObject projectile = Instantiate(projectilePrefab, barrelTransform.position, barrelTransform.rotation);

        // Get the rigidbody of the projectile
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        if (projectileRb != null)
        {
            // Shoot the projectile in the forward direction of the barrel
            projectileRb.velocity = barrelTransform.forward * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile prefab is missing Rigidbody component!");

        }
  
    }

}

