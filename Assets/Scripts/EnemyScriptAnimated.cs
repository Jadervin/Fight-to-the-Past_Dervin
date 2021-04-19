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

        if (!pursuing)
        {
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward * visionRange);

            Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something");
                pursuing = true;
                Shoot();
                animator.SetTrigger("Found");
                //target = hit.transform.gameObject;

            }

        }
        else
        {
            if (target == null)
            {
                pursuing = false;
            }
            //pathfinding.SetDestination(target.transform.position);


        }
    }

}
