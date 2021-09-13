using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start called");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
