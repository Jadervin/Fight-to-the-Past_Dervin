using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject[] projectiles;
    public ParticleSystem MuzzleFlash;
    public int projectileSelected = 0;
    public GameObject muzzle;
    public float cooldownTime;
    public AudioSource soundSource;
    public AudioClip GunShot;

    protected float coolTimer = 0;

    protected void Update()
    {

        ChangeWeapons();
        if(coolTimer>0)
        {
            coolTimer -= Time.deltaTime;
        }


        else if (Input.GetButtonDown("Fire1") && coolTimer <= 0)
        {
            Shoot();
            coolTimer = cooldownTime;
        }

    }




    public void ChangeWeapons()
    {
        float dir = Input.GetAxis("Mouse ScrollWheel");

        if (dir > 0)
        {
            projectileSelected = (projectileSelected + 1) % projectiles.Length;


        }
        else if (dir < 0)
        {
            if (projectileSelected == 0)
            {
                projectileSelected = projectiles.Length - 1;
            }
            else
            {
                projectileSelected = projectileSelected - 1;
            }

        }

        


    }

    public void Shoot()
    {
        GameObject temp;
        Instantiate(MuzzleFlash, muzzle.transform.position, Quaternion.identity);
        temp = Instantiate(projectiles[projectileSelected], muzzle.transform.position, 
           muzzle.transform.rotation);
        soundSource.PlayOneShot(GunShot);

    }
}
