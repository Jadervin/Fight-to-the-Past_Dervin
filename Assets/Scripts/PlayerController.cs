using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 100)]
    public float speed;
    public CharacterController controller;

    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    // Update is called once per frame
    protected void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
       
        Vector3 movement = transform.right * movX + transform.forward * movZ;

        //Vector3 movementVector = new Vector3(movX, gravity, movZ);


        //controller.Move(movementVector * speed * Time.deltaTime);
        controller.Move(movement*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
