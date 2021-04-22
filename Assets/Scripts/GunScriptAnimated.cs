using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScriptAnimated : GunScript
{
    public Animator animator;
    public string animatorTriggerName;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new protected void Update()
    {

        ChangeWeapons();
        if (coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
        }


        else if (Input.GetButtonDown("Fire1") && coolTimer <= 0 && Time.timeScale > 0f)
        {
            Shoot();
            coolTimer = cooldownTime;
            animator.SetTrigger("Shooting");
        }

    }

}
