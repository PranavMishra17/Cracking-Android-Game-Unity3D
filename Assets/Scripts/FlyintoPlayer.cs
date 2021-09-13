using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyintoPlayer : MonoBehaviour
{

    public Rigidbody box;
    public Rigidbody box2;
    public Rigidbody box3;
    public float throwspeed = 12;
    public Transform player;
    public ThrowTrigger tt;
    bool qw = true;
    public GameObject destroyedVersion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        if (qw)
        {
            b.AddForce(0, 20, 0);
            qw = false;
        }

        Vector3 direction = player.transform.position - gameObject.transform.position;
        direction.Normalize();
        b.AddTorque(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        b.AddTorque(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        b.AddForce(direction * throwspeed);
        StartCoroutine(getthisdone());

    }
    IEnumerator getthisdone() {
        yield return new WaitForSeconds(5);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
