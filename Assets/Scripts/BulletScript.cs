using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : HitBoxScript
{

    public float speed;
    public float despawnTime;
    
    float timeAlive = 0;
    public GameObject collisionEffect;



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
        
            
            Destroy(other.gameObject);
            Instantiate(collisionEffect, transform.position, transform.rotation);

            
        
    }
}
