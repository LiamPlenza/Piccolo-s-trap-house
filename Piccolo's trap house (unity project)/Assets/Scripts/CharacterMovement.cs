using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Text PlayerNameText;
    public GameObject PlayerCamera;

    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.5f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Animator animator;

    public int life = 2;

    private float speedIndicator;
    private float timer = 0.0f;

    private void Awake()
    {
        if (photonView.isMine)
        {
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }
/*
    void OnEnable()
    {
    	controller.enabled = true;
	}

    Update is called once per frame*/
    void Update()
    {
      if (photonView.isMine)
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
            speedIndicator = 1;
        }
        else
        {
            animator.SetBool("Running", false);
            speedIndicator = 2;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("Jumping", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (life == 1) {
            timer += Time.deltaTime; 
            if (timer < 3.0f)
                speed = 10.0f;
            else if (speedIndicator == 1)
                speed = 7.5f;
            else if (speedIndicator == 2)
                speed = 3.5f;
        }
        else if (life == 0)
            Destroy(gameObject);
        else if (speedIndicator == 1)
            speed = 8.0f;
        else if (speedIndicator == 2)
            speed = 4.0f;
      }
    }
    public void reduceLife(){
        life -= 1;
    }
}
