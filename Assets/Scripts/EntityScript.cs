using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    [Header("Health Attributes")]
    public int MaxHealth;
    public int HP;

    //public float speed;
    [Header("Sounds")]
    public AudioSource hitSoundSource;
    public AudioClip hitSound;

    protected void Start()
    {
        HP = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(uint dmg)
    {
        hitSoundSource.PlayOneShot(hitSound);
        HP = HP - (int)dmg;
        //HP = Mathf.Clamp(HP - (int)dmg, 0, MaxHealth);

        

    }


}
