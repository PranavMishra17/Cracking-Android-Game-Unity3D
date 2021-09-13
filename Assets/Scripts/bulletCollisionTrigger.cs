using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisionTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy")
        {
            Debug.Log(" Collision Destroy");
            Destroy(gameObject);
        }
        // Debug.Log(" Collision Entered");
        if (other.tag == "Player")
        {
            Debug.Log(" Collision Entered");
        }

    }
}
