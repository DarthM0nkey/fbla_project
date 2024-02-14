using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killOrder : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an enemy object
        if (other.CompareTag("Enemy"))
        {
                       // Destroy the enemy and the projectile
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Destroy the projectile if it collides with anything else
            Destroy(gameObject);
        }
    }
}
