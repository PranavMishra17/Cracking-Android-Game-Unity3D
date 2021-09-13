using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class pauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject htlvlendpanel;
    public GameObject pausemenuUI;
    public Shooting sh;
    public Animator transition;
    public AudioSource maintheme;
    public GPLAY gplay;
    public AdsManager ads;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        ads.HideBanner();
        FindObjectOfType<Audio_Manager>().Play("Button");
        FindObjectOfType<Audio_Manager>().Play("Theme");
        maintheme.Play();
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;

    }
    public void Pause()
    {
        
        FindObjectOfType<Audio_Manager>().Play("Button");
        gplay.UnlockAchievementPause();
        FindObjectOfType<Audio_Manager>().Pause("Theme");
        sh.IncBC();
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        ads.ShowBanner();
    }
    public void QuitGame()
    {

        FindObjectOfType<Audio_Manager>().Play("Button");
        Application.Quit();
    }
    public void LoadMEnu()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        GameisPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Refill()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        sh.Refill();
    }
    public void LoadHTLVL()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        Time.timeScale = 1f;
        SceneManager.LoadScene("HTLVL");
        htlvlendpanel.SetActive(false);
    }
    public void LoadMenuHereee()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        Debug.Log("loadmenu called");
        StartCoroutine(LoadMenuHere());
    }

    IEnumerator LoadMenuHere()
    {
        Debug.Log("ienumerator called");
        transition.Play("HTPEndFinish");
        yield return new WaitForSeconds(1);
        activatepanel.actpanel = false;
        StartCoroutine(Loadhere());

    }
    IEnumerator Loadhere()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
}
