using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensit = 100f;

    public Transform player;
    public Transform eyes;
    //int degrees = 10;

    float yRotation = 0f;
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensit * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensit * Time.deltaTime;

        yRotation -= mouseY;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //xRotation += mouseX;


        eyes.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        

        player.Rotate(Vector3.up * mouseX);
        //player.Rotate(Vector3.forward * mouseY);

        /*
        if (Input.GetMouseButton(1))
        {

            transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            //transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* degrees);
        }
        if (!Input.GetMouseButton(1))
        {
            //transform.RotateAround(target.position, Vector3.up, degrees * Time.deltaTime);
        }
        */
    }

}
