using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision Entered: \'" + col.gameObject.name + "\'");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Player Detected");
            col.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Collision Exited");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Player exited");
            col.gameObject.transform.SetParent(null);
        }
    }

}
