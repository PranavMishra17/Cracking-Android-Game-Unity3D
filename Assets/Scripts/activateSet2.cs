using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSet2 : MonoBehaviour
{
    public PlayerMovement pm;
    public static bool activate2 = false;
    public static bool activate3 = false;
    public static bool activate4 = false;
    public static bool activate5 = false;
    public GameObject Set3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate2 && activate3 && activate4 && activate5 )
        {
            Set3.SetActive(true);
            pm.sp = 2.0f;
        }
    }
}
