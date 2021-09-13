using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{
    public Rigidbody sppp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sppp.AddForce(30, -50, 0);
    }
}
