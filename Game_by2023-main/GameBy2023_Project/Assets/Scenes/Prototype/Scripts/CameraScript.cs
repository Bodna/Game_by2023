using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform ortientation;

    float yRotation;
    float xRotation;

    private void Start()
    {
        //lock cursor in middle and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //read mouse movement and store
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= mouseY;
        yRotation += mouseX;

        //limit vertical rot to 180 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        ortientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
