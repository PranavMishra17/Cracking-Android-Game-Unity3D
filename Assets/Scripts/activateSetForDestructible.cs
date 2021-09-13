using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSetForDestructible : MonoBehaviour
{
    public GameObject Destroybox;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            activateSet.activate = true;
            Destroybox.SetActive(true);

        }
        else if (other.gameObject.tag == "Player")
        {

        }

    }
}
