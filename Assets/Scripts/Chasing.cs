using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float followSpeed = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Enemy follows the player
            FollowPlayer();
        }
        else
        {
            // Enemy stays still
            // Add any other behavior here if needed
        }
    }

    void FollowPlayer()
    {
        // Rotate to face the player
        RotateTowardsPlayer();

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}

