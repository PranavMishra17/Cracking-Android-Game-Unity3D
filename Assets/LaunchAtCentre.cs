using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtCentre : MonoBehaviour
{
    public Rigidbody box;
    public GameObject bottle;
    public float throwspeed = 12;
    public Transform butorigin;
    public ThrowTrigger tt;
    Vector3 dirn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ddd;
        ddd = new Vector3(0f, 0f, bottle.transform.position.z);
        dirn = (ddd - gameObject.transform.position);
        if (tt.throwit)
        {
            Throw(box);
        }

    }

    private void Throw(Rigidbody b)
    {
        Vector3 direction = dirn;
        //Vector3 direction = player.transform.position- gameObject.transform.position;
        direction.Normalize();
        b.AddTorque(Random.Range(0, 12), Random.Range(0, 4), Random.Range(0, 8));
        b.AddForce(direction * throwspeed*20);
        tt.throwit = false;
    }
  
}
