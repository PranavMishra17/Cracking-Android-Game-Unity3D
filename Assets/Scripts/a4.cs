using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a4 : MonoBehaviour
{
    public PlayerMovement pm;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            pm.a4 = true;
            activateSet2.activate4 = true;
        }
        else if (other.gameObject.tag == "Player")
        {

        }

    }
}
