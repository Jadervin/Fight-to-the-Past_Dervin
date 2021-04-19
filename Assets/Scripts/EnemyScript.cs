using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : EntityScript
{

    public NavMeshAgent pathfinding;
    //public GameObject muzzle;
    //public GameObject projectile;
    public GameObject eyes;
    public float visionRange;
    public bool pursuing = false;
    private GameObject target;
    //public GameObject particle;
    public string hurtTag;

    [HideInInspector]
    //public EnemySpawn spawnedBy;

    new private void Start()
    {
        base.Start();
        pathfinding.speed = speed;

    }
   

    // Update is called once per frame
    void Update()
    {

        if(!pursuing)
        {
                Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);

                Debug.DrawRay(ray.origin, ray.direction*visionRange, Color.red);

                RaycastHit hit;

                if(Physics.Raycast(ray, out hit) && hit.transform.tag=="Player")
                {

                     Debug.Log("I see something");
                     pursuing = true;
                     target = hit.transform.gameObject;

                }
                
        }
        else
        {
            if(target==null)
            {
                pursuing = false;
            }
            pathfinding.SetDestination(target.transform.position);


        }
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Barrier")
        {
            pursuing = false;
            pathfinding.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }


    
}
