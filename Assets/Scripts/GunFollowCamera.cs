using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowCamera : MonoBehaviour
{
    private Camera playerCamera;

    void Start()
    {
        // Find the main camera in the scene
        playerCamera = Camera.main;

        if (playerCamera == null)
        {
            Debug.LogError("Main camera not found in the scene. Make sure you have a camera tagged as MainCamera.");
        }
    }

    void Update()
    {
        if (playerCamera != null)
        {
            // Align the gun's rotation with the camera's rotation
            transform.rotation = playerCamera.transform.rotation;
        }
    }
}



