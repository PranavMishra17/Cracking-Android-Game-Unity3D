using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour
{
    Animator openl, openr;
    public GameObject OpenL, OpenR, planeAcive, planeDeactive;
    public Material mat;
    public bool lvlChange = true;
    public PlayerMovement pm;
    public Material Material1;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;

    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        openl = OpenL.GetComponent<Animator>();
        openr = OpenR.GetComponent<Animator>();
        if (other.tag == "Player")
        {
            planeDeactive.SetActive(false);
            openl.Play("GateOpenAnimationL");
            openr.Play("GateOpenAnimation");
            pm.rotatee = true;
            if (lvlChange)
            {
                RenderSettings.skybox = mat;
                
                Object.GetComponent<MeshRenderer>().material = Material1;
                DynamicGI.UpdateEnvironment();
            }
            
        }

    }
}
