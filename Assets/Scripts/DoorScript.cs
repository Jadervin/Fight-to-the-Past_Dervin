using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject doorExplosionEffect;
    public AudioSource soundSource;
    public AudioClip doorExplosionSound;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ("Bullet"))
        {
            Destroy(other.gameObject);
            Instantiate(doorExplosionEffect, transform.position, Quaternion.identity);
            soundSource.PlayOneShot(doorExplosionSound);
            Destroy(this.gameObject);
        }

        



    }

}
