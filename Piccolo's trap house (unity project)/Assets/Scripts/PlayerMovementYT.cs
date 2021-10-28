using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementYT : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -20f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            animator.SetBool("Running", true);
            speed = 8f;
        }
        else
        {
            animator.SetBool("Running", false);
            speed = 4f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack",true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        //if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        //{
        //    animator.SetBool("Picking", true);
        //}
        //else
        //{
        //    animator.SetBool("Picking", false);
        //}

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
