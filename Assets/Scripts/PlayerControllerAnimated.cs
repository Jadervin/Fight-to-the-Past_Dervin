using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimated : PlayerController
{
    public Animator animator;
    public float normalSpeed;
    Vector3 velo;
    bool isGround;

    private void Start()
    {
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
        //float grav = Physics.gravity.y * Time.deltaTime;

        /*
        float movX = fX * speed * Time.deltaTime;
        float movZ = fZ * speed * Time.deltaTime;
        

        */
        //Vector3 movementVector = new Vector3(fX, grav, fZ);

        Vector3 movement = transform.right * fX + transform.forward * fZ;

        animator.SetFloat("x", fX);
        animator.SetFloat("y", fZ);

        controller.Move(movement * speed * Time.deltaTime);
        //controller.Move(movementVector * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velo.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velo.y += gravity * Time.deltaTime;
        controller.Move(velo*Time.deltaTime);

        
    }

    // Start is called before the first frame update


}
