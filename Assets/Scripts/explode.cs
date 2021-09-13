using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public Shooting sh;
    public Rigidbody tube;
    public RopeControllerRealisticNoSpring rope;

    public float cubeSize = 0.125f;
    public int cubesInRow = 8;
    public throwaway taway;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = .02f;
    public float explosionRadius = .1f;
    public float explosionUpward = 0.02f;

    public bool explodebool = false, timebomb = false;

    public Material gamepiecemat;
    // Use this for initialization
    void Start()
    {
        if (timebomb)
        {
            StartCoroutine(TriggerExplode());
        }
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }
    public IEnumerator TriggerExplode()
    {
        yield return new WaitForSeconds(4f);
        explodecube();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
           Debug.Log("Explode called");
            explodecube();
            sh.UpdateBulletText5();
            tube.useGravity = true;
            taway.throwawayset();
            //rope.rope_detached = true;
        }
        if (other.tag == "Destroy")
        {
            Debug.Log("Explode called");
            explodecube();
            //sh.UpdateBulletText5();
            tube.useGravity = true;
            //rope.rope_detached = true;
        }

    }

    public void explodecube()
    {
        FindObjectOfType<Audio_Manager>().Play("CubeSmash");
        //make object disappear
        gameObject.SetActive(false);
        

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && explodebool)
            {
              //add explosion force to this body with given parameters
              rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
                
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer render = piece.GetComponent<Renderer>();
        render.material = gamepiecemat;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 0.1f;
        

    }
}
