using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class GPLAY : MonoBehaviour
{
    public GameObject signinPanel1, signinPanel2;
    void Start()
    {
        DontDestroyOnLoad(this);
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0)
        {
            if (Social.localUser.authenticated)
            {
                //
            }
            else
            {
                LoginUser();
            }
            
        }
    }
    public void LoginUser()
    {
        Debug.Log("LoginUser called");
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool succeess) => { });
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    public void AddScoreToLeaderboard(int score)
    {
        Debug.Log("Adding score");
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, "CgkIsMK62NkaEAIQBw", success => { });
        }
    }
    public void ShowLeaderboard()
    {
        Debug.Log("Show Leaderboard");
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            signinPanel1.SetActive(true);
            StartCoroutine(disable1(signinPanel1));
            LoginUser();
        }
    }
    public void ShowAchievements()
    {
        Debug.Log("Show Achieve");
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            signinPanel2.SetActive(true);
            StartCoroutine(disable1(signinPanel2));
            LoginUser();
        }
    }
    public void UnlockAchievementVirgin()
    {
        Debug.Log("Achieve VIrgin");
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIsMK62NkaEAIQAQ", 100f, success => { });
        }
    }
    public void UnlockAchievementChad()
    {
        Debug.Log("Achieve Chad");
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIsMK62NkaEAIQAg", 100f, success => { });
        }
    }
    public void UnlockAchievementLastgasp()
    {
        Debug.Log("Achieve Lastgasp");
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIsMK62NkaEAIQBA", 100f, success => { });
        }
    }
    public void UnlockAchievementComfy()
    {
        Debug.Log("Achieve Comfy");
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIsMK62NkaEAIQAw", 100f, success => { });
        }
    }
    public void UnlockAchievementPause()
    {
        Debug.Log("Achieve Pause");
        if (Social.localUser.authenticated)
        {
            
            Social.ReportProgress("CgkIsMK62NkaEAIQBg", 100f, success => { });
        }
    }
    public void UnlockAchievementStart()
    {
        Debug.Log("Achieve Start");
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkIsMK62NkaEAIQBQ", 100f, success => { });
        }
    }

    IEnumerator disable1(GameObject panel)
    {
        yield return new WaitForSeconds(3);
        panel.SetActive(false);
    }
}
