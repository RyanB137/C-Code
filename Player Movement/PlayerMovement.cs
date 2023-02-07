using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Character Controller Variable.
    public CharacterController controller;

    //Variable For A Vector 3
    Vector3 velocity;

    //Stats
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Ground Check
    public Transform groundCheck; 
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Update()
    {   //Checks If Collider Is Inside Something With The Layer "Ground"
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //keeps player on ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Creates New Variable For Axis Which Sets Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Creates A Variable For Vector 3 Which Represents Movement Direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Adds Speed To The Movement
        controller.Move(move * speed * Time.deltaTime);

        //Lets you jump when press jump input
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Sets Velocity.y for gravity
        velocity.y += gravity * Time.deltaTime;

        //Creates a Movement Value Based On Movement Velocity And Time
        controller.Move(velocity * Time.deltaTime);
    }
}
