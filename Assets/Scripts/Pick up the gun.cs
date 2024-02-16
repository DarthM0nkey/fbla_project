using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private GameObject currentGun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpGun();
        }
    }

    void TryPickUpGun()
    {
        // Cast a ray from the center of the camera to check for objects with a collider
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has the "Gun" tag
            if (hit.collider.CompareTag("Gun"))
            {
                // If the player is already holding a gun, drop it
                if (currentGun != null)
                {
                    DropGun();
                }

                // Pick up the new gun
                PickUpGun(hit.collider.gameObject);
            }
        }
    }

    void PickUpGun(GameObject gunToPickUp)
    {
        // Attach the gun to the player at the specified position
        gunToPickUp.transform.parent = transform;
        gunToPickUp.transform.localPosition = new Vector3(0, 0, 1); // Adjust the position as needed
        gunToPickUp.transform.localRotation = Quaternion.identity;

        // Disable the gun's collider and renderer to prevent duplicate interactions
        gunToPickUp.GetComponent<Collider>().enabled = false;
        gunToPickUp.GetComponent<Renderer>().enabled = false;

        // Update the currentGun variable
        currentGun = gunToPickUp;
    }

    void DropGun()
    {
        // Detach the current gun from the player
        currentGun.transform.parent = null;

        // Enable the collider and renderer of the dropped gun
        currentGun.GetComponent<Collider>().enabled = true;
        currentGun.GetComponent<Renderer>().enabled = true;

        // Reset the currentGun variable
        currentGun = null;
    }
}

