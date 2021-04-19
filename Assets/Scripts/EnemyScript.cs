using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : EntityScript
{

    public NavMeshAgent pathfinding;
    public GameObject eyes;
    public float visionRange;
    public bool pursuing = false;
    private GameObject target;
    public string hurtTag;

    [Header("Gun Script Attributes")]
    public GameObject[] projectiles;
    public ParticleSystem MuzzleFlash;
    public int projectileSelected = 0;
    public GameObject muzzle;
    public float cooldownTime;
    protected float coolTimer = 0;

    new private void Start()
    {
        base.Start();
        //pathfinding.speed = speed;

    }
   

    // Update is called once per frame
    protected void Update()
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
                    Shoot();
                //target = hit.transform.gameObject;

            }
                
        }
        else
        {
            if(target==null)
            {
                pursuing = false;
            }
            //pathfinding.SetDestination(target.transform.position);


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


    public void Shoot()
    {
        GameObject temp;
        //MuzzleFlash.Play();
        temp = Instantiate(projectiles[projectileSelected], muzzle.transform.position,
           muzzle.transform.rotation);

    }



}
