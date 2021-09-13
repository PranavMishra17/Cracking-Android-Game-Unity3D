using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatepanel : MonoBehaviour
{
    public GameObject LastPanel;
    public GameObject DisablePanel;
    public static bool actpanel = false;

    // Update is called once per frame
    void Update()
    {
        if (actpanel)
        {
            LastPanel.SetActive(true);
            DisablePanel.SetActive(false);
        }
    }
}
