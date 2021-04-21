using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject barrelEexplosionEffect;
    //public MeshRenderer barrelMesh;
    public float radius = 5f;
    public float force = 700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Bullet"))
        {
            Destroy(this.gameObject);
            //barrelMesh.GetComponent<MeshRenderer>().enabled = false;
            Instantiate(barrelEexplosionEffect, this.transform.position, this.transform.rotation);
        }


        
    }
    
    void Explode()
    {
        Instantiate(barrelEexplosionEffect, this.transform.position, this.transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                //Destroy(rb);

                rb.AddExplosionForce(force, this.transform.position, radius);
            }
        }
    }
}
