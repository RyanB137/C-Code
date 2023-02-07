using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Changable Variable For Senstivity
    public float mouseSensitivity = 100f;

    //Variable Which References The Playerbody
    public Transform playerBody;

    //A set variable for rotation on the x axis
    float xRotation = 0f;

    void Start()
    {   //Locks The Cursor So You Cant Move It
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   //Calculates Mouse Movement And Makes It A Float.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Updates xRotation Based On Mouse Movement
        xRotation -= mouseY;
        //Limits Rotation So You Can Only Look 90 Degrees Up And Down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates Player Around x-axis Based On The Value Of xRotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Rotates Player Around Y-axis Based On The Value Of mouseX
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
