using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
    public float rotatesp = 100;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatesp * Time.deltaTime, 0);
        //transform.Rotate(rotatesp* 0.5f * Time.deltaTime, 0,0);
    }
}

