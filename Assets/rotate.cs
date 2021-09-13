using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotatesp = 150;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatesp * Time.deltaTime, 0);
    }
}
