using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    [Range(0, 100)]
    public float speed;
    public CharacterController controller;

    // Update is called once per frame
    protected void Update()
    {
        float movX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float movZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float gravity = Physics.gravity.y * Time.deltaTime;


        Vector3 movementVector = new Vector3(movX, gravity, movZ);



        controller.Move(movementVector);

        //(1,0,0) Vector3 right
        //(0,1,0) Vector3 up
        //(0,0,1) Vector3 forward
    }
}
