using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a3 : MonoBehaviour
{
    public PlayerMovement pm;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            pm.a2 = true;
            activateSet2.activate3 = true;
        }
        else if (other.gameObject.tag == "Player")
        {

        }

    }
}
