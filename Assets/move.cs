using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public bool movvveee = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movvveee)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3);
        }
    }
}
