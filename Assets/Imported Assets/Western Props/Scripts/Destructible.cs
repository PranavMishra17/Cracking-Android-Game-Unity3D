// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public Shooting sh;
    public string objecttype;
    public string audioclipname;
	public GameObject destroyedVersion; // Reference to the shattered version of the object

    public void Start()
    {
        if (objecttype == "Box")
        {
            audioclipname = "CrateSmash";
        }
        else
            audioclipname = "BottleSmash";
    }
    void OnCollisionEnter(Collision other)
    {
       // Debug.Log(" Collision Entered");
        if (other.gameObject.tag == "Death")
        {
            sh.UpdateBulletText();
            Debug.Log("Death Detected");
            // Spawn a shattered object
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            // Remove the current object
            Destroy(gameObject);
            FindObjectOfType<Audio_Manager>().Play(audioclipname);
        }
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("Death Detected");
            // Spawn a shattered object
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            // Remove the current object
            Destroy(gameObject);
            FindObjectOfType<Audio_Manager>().Play(audioclipname);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "Player")
        {
            
            Debug.Log("Death Detected");
            // Spawn a shattered object
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            // Remove the current object
            Destroy(gameObject);
        }
        if (other.tag == "Death")
        {
            
            sh.UpdateBulletText();
            Debug.Log("Death Detected");
            // Spawn a shattered object
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            // Remove the current object
            Destroy(gameObject);
        }*/
    }

}
