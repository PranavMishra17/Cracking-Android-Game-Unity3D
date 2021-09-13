using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accc : MonoBehaviour
{
    public Shooting sh;
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            Debug.Log("accc called");
            activatepanel.actpanel = true;
            sh.canshoot = false;
        }
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("accc called");
            activatepanel.actpanel = true;
            sh.canshoot = false;
        }
    }
}
