using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtRocks : MonoBehaviour
{
    public Rigidbody cube;
    public GameObject target;
    public float throwspeed = 40, playerOffset = 5f;
    public bool TargetPlayer = false;
    //public Transform butorigin;
    public ThrowTrigger tt;
    Vector3 dirn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPlayer)
        {
            Vector3 ddd;
            ddd = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z+ playerOffset);
            //ddd = new Vector3(0f, 0f, target.transform.position.z);
            dirn = (ddd - gameObject.transform.position);
        }
        else
        {
            Vector3 ddd;
            ddd = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            //ddd = new Vector3(0f, 0f, target.transform.position.z);
            dirn = (ddd - gameObject.transform.position);
        }

        if (tt.throwit)
        {
            Throw(cube);
        }

    }

    private void Throw(Rigidbody b)
    {
        Vector3 direction = dirn;
        //Vector3 direction = player.transform.position- gameObject.transform.position;
        direction.Normalize();
        b.AddTorque(Random.Range(0, 12), Random.Range(0, 4), Random.Range(0, 8));
        b.AddForce(direction * throwspeed * 20);
        tt.throwit = false;
    }
}
