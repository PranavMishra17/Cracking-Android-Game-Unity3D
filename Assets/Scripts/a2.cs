using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a2 : MonoBehaviour
{
    public PlayerMovement pm;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            pm.a1 = true;
            activateSet2.activate2 = true;
        }
        else if (other.gameObject.tag == "Player")
        {

        }

    }
}
