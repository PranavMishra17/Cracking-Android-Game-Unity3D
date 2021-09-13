using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    Animator bloodOverlay;
    public GameObject BloodOverlayScreen;
    public Rigidbody projectile;
    public Rigidbody player;
    public Rigidbody currentBullet;
    public float shootspeed = 20;
    bool touch;
    public int bullet_Count = 30;
    public Text instruction, endscore;
    public CameraShake cs;
    public bool canshoot = true;
    public Material Material1;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;
    private bool Chad = true, virgin = true;
    public GPLAY gplay;
    public AdsManager ads;
    public bool deathforONCE = true;

    // public AudioSource maintheme;
    //public AudioClip Box_Smash, Bottle_Smash, Death, Cube_Smash, Shoot_Effect;

    // Start is called before the first frame update
    void Start()
    {
        //ads.ShowBanner();
        Chad = true; virgin = true;
        Object.GetComponent<MeshRenderer>().material = Material1;
        bloodOverlay = BloodOverlayScreen.GetComponent<Animator>();
        bullet_Count = 25;
        touch = true;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0)
        {
            canshoot = false;
        }
        else
        {
            canshoot = true;
            if (currentScene.buildIndex == 1)
            {
                gplay.UnlockAchievementStart();
                Debug.Log("Achieve Start...");
            }
            
        }
        if (currentScene.buildIndex == 2)
        {
            bullet_Count = 100;
            ads.ShowBanner();
        }
        instruction.text = ("" + bullet_Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameisPaused ==false )
        {
            if (Input.touchCount > 0 && canshoot)
            {
                deathforONCE = true;
                if (touch)
                {
                    Debug.Log("touch is true");
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition); //draws ray from camera to touch position
                    Debug.DrawRay(r.origin, r.direction * 10, Color.cyan);

                    shoot(r);
                    touch = false;
                }
                
            }
            else
            {
                touch = true;
            }
        }
        if (bullet_Count == 0)
        {
           if (deathforONCE)
           {
                DeathCall();
           }
            deathforONCE = false;

        }
        
    }

    void shoot(Ray r)
    {
        Debug.Log("Shoot called");
        FindObjectOfType<Audio_Manager>().Play("Shooting");
        if (bullet_Count > 0)
        {
            bullet_Count--;
            instruction.text = ("" + bullet_Count);
            Rigidbody bullet = Instantiate(projectile, player.position, Quaternion.LookRotation(r.direction)) as Rigidbody;
            currentBullet = bullet;
            bullet.AddForce(r.direction * shootspeed);
        }
    }

    public void UpdateBulletText()
    {
       // Debug.Log("UpdateBulletCount Called at "+bullet_Count);

        bullet_Count = bullet_Count + 2;
       //Debug.Log("UpdateBulletCount now "+bullet_Count);
        instruction.text = ("" + bullet_Count);
    }
    public void UpdateBulletText5()
    {
        // Debug.Log("UpdateBulletCount Called at "+bullet_Count);

        bullet_Count = bullet_Count + 4;
        //Debug.Log("UpdateBulletCount now "+bullet_Count);
        instruction.text = ("" + bullet_Count);
    }

    private void B()
    {
      //  Debug.Log("B called");  
        
        bloodOverlay.Play("BloodOverlay",-1,0f);
        
    }

    void OnTriggerEnter(Collider other)
    {

        // Debug.Log(" Collision Entered");
        if (other.tag == "Destroy")
        {
            FindObjectOfType<Audio_Manager>().Play("Hit");
            B();
            bullet_Count = bullet_Count - 15;
            cs.shakeDuration = 0.8f;
            virgin = false;
            if (bullet_Count > 0)
            {
                instruction.text = ("" + bullet_Count);
            }
            else
            {
                bullet_Count = 0;
                instruction.text = ("" + bullet_Count);
                //DeathCall();
            }
        }

    }

    public void DeathCall()
    {
        Debug.Log("DEATH CALLED");
        canshoot = false;
        FindObjectOfType<Audio_Manager>().Pause("Theme");
        FindObjectOfType<Audio_Manager>().Play("Death");
        bullet_Count = 0;
        instruction.text = ("" + bullet_Count);
        Chad = false;
        //deathforONCE = false;
    }
    public void Revive()
    {
        canshoot = true;
        FindObjectOfType<Audio_Manager>().Play("Theme");
        bullet_Count = 21;
        instruction.text = ("" + bullet_Count);
        deathforONCE = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            B();
            bullet_Count = bullet_Count - 15;
            cs.shakeDuration = 0.8f;
            instruction.text = ("" + bullet_Count);
        }
    }
    public void IncBC()
    {
        bullet_Count++;
        instruction.text = ("" + bullet_Count);
        currentBullet.gameObject.SetActive(false);
    }
    public void Refill()
    {
        bullet_Count = 25;
        instruction.text = ("" + bullet_Count);
    }
    public void EndScore()
    {
        endscore.text = ("Final Score: " + bullet_Count);
        
    }
    public void CheckAchievements()
    {
        gplay.AddScoreToLeaderboard(bullet_Count);
        if (bullet_Count > 30)
        {
            Debug.Log("Achieve Comfy...");
            gplay.UnlockAchievementComfy();
        }
        else
        {
            Debug.Log("Achieve LastGasp....");
            gplay.UnlockAchievementLastgasp();
        }
        if (Chad)
        {
            Debug.Log("Achieve Chad...");
            gplay.UnlockAchievementChad();
        }
        if (virgin)
        {
            Debug.Log("Achieve Virgin...");
            gplay.UnlockAchievementVirgin();
        }
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        Debug.Log("Fadeout called");
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
            Debug.Log("yield called");
        }
    }
  }
