using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject optmenuUI;
    public GameObject mainmenuUI;
    public GPLAY gplay;

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToMenu()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        optmenuUI.SetActive(false);
        mainmenuUI.SetActive(true);

    }
    public void Options()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        optmenuUI.SetActive(true);
        mainmenuUI.SetActive(false);
    }
    public void QuitGame()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        Application.Quit();
    }
    public void LoadLvl()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        SceneManager.LoadScene("LVL");
    }
    public void LoadHTLVL()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        SceneManager.LoadScene("HTLVL");
    }
    public void ShowAchievements()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        gplay.ShowAchievements();
    }
    public void ShowLeaderBoard()
    {
        FindObjectOfType<Audio_Manager>().Play("Button");
        gplay.ShowLeaderboard();
    }
}
