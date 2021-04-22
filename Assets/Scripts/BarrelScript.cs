using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject barrelEexplosionEffect;
    
    public float radius = 5f;
    public float force = 700f;

    public AudioSource soundSource;
    public AudioClip explosionSound;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Bullet"))
        {
            Destroy(this.gameObject);
            //barrelMesh.GetComponent<MeshRenderer>().enabled = false;
            Explode();
        }


        
    }
    
    void Explode()
    {
        Instantiate(barrelEexplosionEffect, this.transform.position, this.transform.rotation);
        soundSource.PlayOneShot(explosionSound);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb!=null)
            {
                //Destroy(rb);

                rb.AddExplosionForce(force, transform.position, radius);
            }

            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest!=null)
            {
                dest.Destroy();

            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(this.transform.position, radius);
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
