using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtPlayer : MonoBehaviour
{
    public Rigidbody box;
    public Rigidbody box2;
    public Rigidbody box3;
    public float throwspeed =12;
    public Transform player;
    public Transform butorigin;
    public ThrowTrigger tt;
    Vector3 dirn;
    public GameObject destroyedVersion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirn = (butorigin.transform.position - gameObject.transform.position);
        if (tt.throwit)
        {
           // box2.AddTorque(Random.Range(0, 10),Random.Range(0, 10), Random.Range(0, 10));
           // box3.AddTorque(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
            Throw(box);
          //Invoke("Throw2", 2);
        }
        
    }

    private void Throw(Rigidbody b)
    {
        Vector3 direction = dirn;
        //Vector3 direction = player.transform.position- gameObject.transform.position;
        direction.Normalize();
        b.AddTorque(Random.Range(0, 12), Random.Range(0, 4), Random.Range(0, 8));
        b.AddForce(direction * throwspeed);
        StartCoroutine(MoveTank());
    }
    IEnumerator MoveTank() {
        yield return new WaitForSeconds(3.5f);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void Throw2()
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        direction.Normalize();
        box2.AddTorque(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        box2.AddForce(direction * throwspeed);
    }
}
