using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensit = 100f;

    public Transform player;
    //int degrees = 10;

    float xRotation = 0f;
    float yRotation = 0f;

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

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;


        player.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

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
