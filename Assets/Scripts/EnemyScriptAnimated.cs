using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptAnimated : EnemyScript
{
    public Animator animator;
    public string animatorTriggerName;
    private GameObject target;

    new void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    new protected void Update()
    {

        if (!found)
        {
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);

            Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something");
                found = true;
                if (coolTimer <= 0)
                {
                    Shoot();
                    animator.SetTrigger("Found");
                    coolTimer = cooldownTime;
                }

                //animator.SetTrigger("Found");
                target = hit.transform.gameObject;

            }

        }
        else
        {
            this.transform.LookAt(target.transform, Vector3.up);

            RaycastHit hit;

            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);
            Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something");
                found = true;

                if (coolTimer <= 0)
                {
                    Shoot();
                    animator.SetTrigger("Found");
                    coolTimer = cooldownTime;
                }

                //animator.SetTrigger("Found");
                //target = hit.transform.gameObject;

            }

            if (target == null)
            {
                found = false;
            }
            //pathfinding.SetDestination(target.transform.position);


        }

        if (coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
        }

        
    }

}
