using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimated : PlayerController
{
    public Animator animator;
    public float normalSpeed;

    private void Start()
    {
        float iLerp = (speed - 0) / (normalSpeed - 0);
        animator.SetFloat("SpeedMultiply", iLerp);
    }

    new protected void Update()
    {
        float fX = Input.GetAxis("Horizontal");
        float fZ = Input.GetAxis("Vertical");


        float movX = fX * speed * Time.deltaTime;
        float movZ = fZ * speed * Time.deltaTime;
        float gravity = Physics.gravity.y * Time.deltaTime;


        Vector3 movementVector = new Vector3(movX, gravity, movZ);



        

        animator.SetFloat("x", fX);
        animator.SetFloat("y", fZ);
        

        controller.Move(movementVector);

        //(1,0,0) Vector3 right
        //(0,1,0) Vector3 up
        //(0,0,1) Vector3 forward
    }

    // Start is called before the first frame update
    
   
}
