using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimated : PlayerController
{
    public Animator animator;
    public float normalSpeed;
    Vector3 velo;
    bool isGround;
    bool isInvincibile = false;
    
    public float invincibilityTime = 3;
    public float waitTime = 3;
    

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
            //hitSoundSource.PlayOneShot(hitSound);

            if (HP <= 0)
            {
                GunMesh.GetComponent <MeshRenderer>().enabled = false;
                //Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
                StartCoroutine(Wait(waitTime));

            }
            else
            {

                StartCoroutine(playerInvincibility());
            }
        }

    }


    IEnumerator playerInvincibility()
    {
        isInvincibile = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibile = false;
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        //SceneManager.LoadScene(youLose);
    }

}
