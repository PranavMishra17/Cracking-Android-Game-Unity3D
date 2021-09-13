using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a5 : MonoBehaviour
{
    public PlayerMovement pm;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            activateSet2.activate5 = true;
            pm.a3 = true;

        }
        else if (other.gameObject.tag == "Player")
        {

        }

    }
}
