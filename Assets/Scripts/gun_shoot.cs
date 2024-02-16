using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float shootInterval = 0.5f;
    public int numberOfBullets = 3;

    private float nextShootTime;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;

            // Optional: You can add additional logic or properties to the bullets here if needed.
        }
    }
}

