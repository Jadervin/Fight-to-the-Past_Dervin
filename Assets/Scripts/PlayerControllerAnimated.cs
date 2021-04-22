using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerAnimated : PlayerController
{
    [Header("Sounds")]
    public AudioSource soundSource;
    public AudioClip DeathSound;
    public AudioClip JumpSound;

    [Header("Damage Attributes")]
    public float invincibilityTime = 3;
    bool isInvincibile = false;
    public float waitTime = 3;
    public GameObject hitEffect;
    public GameObject playerExplosion;
    public GameObject playerModel;

    [Header("Animated Attributes")]
    public Animator animator;
    public float normalSpeed;
    public string isDeadTrigger;

    [Header("Controller Attributes")]
    Vector3 velo;
    bool isGround;
    

    [Header("Scene Names")]
    public string youWin;
    public string youLose;

    [Header("Menu")]
    public GameObject ShieldIcon;

    
    new private void Start()
    {
        base.Start();
        float iLerp = (speed - 0) / (normalSpeed - 0);
        animator.SetFloat("SpeedMultiply", iLerp);
    }

    new protected void Update()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if(isGround&&velo.y<0)
        {

            velo.y = -2f;
        }

        float fX = Input.GetAxis("Horizontal");
        float fZ = Input.GetAxis("Vertical");
        
        Vector3 movement = transform.right * fX + transform.forward * fZ;

        animator.SetFloat("x", fX);
        animator.SetFloat("y", fZ);

        controller.Move(movement * speed * Time.deltaTime);
       

        if(Input.GetButtonDown("Jump") && isGround)
        {
            soundSource.PlayOneShot(JumpSound);
            velo.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velo.y += gravity * Time.deltaTime;
        controller.Move(velo*Time.deltaTime);

        
    }


    private void OnTriggerEnter(Collider other)
    {


        //doorSoundSource.PlayOneShot(hitSound);
        HitBoxScript hit;

        if (!isInvincibile && other.TryGetComponent<HitBoxScript>(out hit))
        {

            Damage((uint)hit.damage);
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            

            if (HP <= 0)
            {
                //GunMesh.GetComponent <MeshRenderer>().enabled = false;
                Destroy(playerModel);
                Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
                soundSource.PlayOneShot(DeathSound);
                StartCoroutine(Wait(waitTime));

            }
            else
            {

                StartCoroutine(playerInvincibility());
            }
        }

        if(other.gameObject.tag == ("Win"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(youWin);
        }

        if (other.gameObject.tag == ("End"))
        {
            Destroy(playerModel);
            Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
            soundSource.PlayOneShot(DeathSound);
            StartCoroutine(Wait(waitTime));

        }

    }


    IEnumerator playerInvincibility()
    {
        isInvincibile = true;
        ShieldIcon.SetActive(true);
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibile = false;
        ShieldIcon.SetActive(false);
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(youLose);
    }

}
