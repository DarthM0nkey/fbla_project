using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Entered: \'" + other.gameObject.name + "\'");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player Detected");
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision Exited");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player exited");
            other.gameObject.transform.SetParent(null);
        }
    }

}
