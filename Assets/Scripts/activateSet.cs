using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSet : MonoBehaviour
{
    public static bool activate = false;
    public GameObject Set2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            Set2.SetActive(true);
        }
    }
}
