using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : HitBoxScript
{

    public float speed;
    public float despawnTime;
    
    float timeAlive = 0;
    //public GameObject collisionEffect;



    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
       
        //(x,y,z )* speed = (speed*x,speed*y,speed*z)
        //(1,0,0)* speed = (speed,0,0)

        timeAlive += Time.deltaTime;

        if(timeAlive>despawnTime)
        {
            Destroy(this.gameObject);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ("Door"))
        {
            Destroy(other.gameObject);
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            //soundSource.PlayOneShot(kill);
            Destroy(this.gameObject);
        }

        
        Destroy(this.gameObject);
            //Instantiate(collisionEffect, transform.position, transform.rotation);
        
            
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Door"))
        {
            Destroy(collision.gameObject);
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            //soundSource.PlayOneShot(kill);
            Destroy(this.gameObject);
        }

    }
}
