using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float sp = 1000, rotsp = 0.3f;
    public Shooting sh;
    public GameObject OutofBallsUI;
    float t = 0.5f;
    public bool rott = false, rotatee = false, lerpBool = false, howTOplay = false;
    public Rigidbody rb;
    bool stopstop = true;
    public GameObject pausebutton;
    public bool a1=false, a2=false, a3=false, a4=false;
    public move mv;


    void Start()
    {
        rotatee = false;
        DynamicGI.UpdateEnvironment();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 2)
        {
          //  sp = 0;
        }

    }
    public void Lerp_back()
    {
        Debug.Log("Lerp called");
        Quaternion currentRotation = rb.transform.rotation;
        Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
        rb.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, rotsp);
    }
    public void EEE()
    {
        mv.movvveee = true;
    }
    void Rotateee()
    {
        transform.Rotate(0,0, rotsp);
    }
    void FixedUpdate()
    {

        if (rotatee)
        {
            Rotateee();
        }
        if (lerpBool)
        {
            Lerp_back();
            StartCoroutine(SetLerpBool());
        }
        if (howTOplay)
        {
            Debug.Log("in How to Play");
            if (a1 && a2 && a3 && a4)
            {
                Debug.Log("all true");
                EEE();
            }
        }
        if (sh.bullet_Count > 0)
        {
           
            pausebutton.SetActive(true);
            transform.Translate(Vector3.forward * Time.deltaTime * sp);
        }
        else
        {
            pausebutton.SetActive(false);
            if (stopstop)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * sp);
                StartCoroutine(movvee());
            }

        }

        
        
    }
    IEnumerator movvee()
    {
        Debug.Log("movvee called");
        yield return new WaitForSeconds(1);
         stopstop = false;
        OutofBallsUI.SetActive(true);
    }
    public void ReloadLevel()
    {
        Debug.Log("reload called");
        SceneManager.LoadScene("LVL");
    }
    public void Revive()
    {
        OutofBallsUI.SetActive(false);
        pausebutton.SetActive(true);
        stopstop = true;
        sh.Revive();
        
    }
    IEnumerator SetLerpBool()
    {
        yield return new WaitForSeconds(5);
        lerpBool = false;
    }
    IEnumerator SlowRotate()
    {
        if (rott)
        {
            rott = false;
            Debug.Log("SlowRotate called");
            yield return new WaitForSeconds(5);
            rotsp = rotsp - 0.02f;
            //rott = true;
            Debug.Log("SlowRotate Done called");
        }
    }
    public void Slowrotatee()
    {
        rott = true;
        StartCoroutine(SlowRotate());
    }

}


