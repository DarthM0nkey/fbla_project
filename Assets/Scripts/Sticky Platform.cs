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
            Vector3 new_scale = new Vector3(
                other.gameObject.transform.localScale.x / transform.localScale.x,    
                other.gameObject.transform.localScale.y / transform.localScale.y,
                other.gameObject.transform.localScale.z / transform.localScale.z
            );
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localScale = new_scale;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision Exited");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player exited");
            Vector3 new_scale = new Vector3(1, 1, 1);
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.localScale = new_scale;
        }
    }

}
