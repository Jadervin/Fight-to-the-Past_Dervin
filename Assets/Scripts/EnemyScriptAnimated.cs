using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptAnimated : EnemyScript
{
    public Animator animator;
    public string animatorTriggerName;
    
    public float ArmTime;


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

            Debug.DrawRay(ray.origin, ray.direction.normalized * visionRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something");
                found = true;
                if (coolTimer <= 0)
                {
                    StartCoroutine(Wait(ArmTime));
                    animator.SetBool("Shoot", true);
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
            Debug.DrawRay(ray.origin, ray.direction.normalized * visionRange, Color.red);

            if (Physics.Raycast(ray, out hit, visionRange) && hit.transform.tag == "Player")
            {

                Debug.Log("I see something in my face at " + Vector3.Distance(this.transform.position, hit.point));
                found = true;

                if (coolTimer <= 0)
                {
                    StartCoroutine(Wait(ArmTime));
                    animator.SetBool("Shoot", true);
                    coolTimer = cooldownTime;
                }

                //animator.SetTrigger("Found");
                //target = hit.transform.gameObject;

            }
            else
            {
                animator.SetBool("Shoot", false);
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

    private void OnTriggerEnter(Collider other)
    {

        HitBoxScript hit;

        if (other.TryGetComponent<HitBoxScript>(out hit))
        {

            Damage((uint)hit.damage);
            //hitSoundSource.PlayOneShot(hitSound);

            if (HP <= 0)
            {
                Destroy(this.gameObject);

            }



        }

    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        Shoot();
        
        //SceneManager.LoadScene(youLose);
    }


}
