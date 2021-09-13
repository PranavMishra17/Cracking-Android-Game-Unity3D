using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrowTrigger : MonoBehaviour
{
    public bool throwit, EndGame = false;
    public bool stopRotation = false, throwrocks = false, texttrigger = false;
    public PlayerMovement pmm;
    public GameObject endUI, pauseUI, scoreUI;
    public Shooting sss;
    public GameObject text3d;

    IEnumerator movvee()
    {
        Debug.Log("movvee called");
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("Menu");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            throwit = true;
            if (texttrigger)
            {
                text3d.SetActive(true);
            }
        }
        if (other.tag == "Death")
        {
            if (throwrocks)
            {
                throwit = true;
            }
        }
        if (stopRotation)
        {
            Debug.Log("Stop_Rotation called");
            pmm.rotatee = false;
            pmm.lerpBool = true;
        }
        if (EndGame)
        {
            endUI.SetActive(true);
            pauseUI.SetActive(false);
            scoreUI.SetActive(false);
            sss.EndScore();
            StartCoroutine(movvee());
            sss.CheckAchievements();
            sss.canshoot = false;
        }
    }
}
