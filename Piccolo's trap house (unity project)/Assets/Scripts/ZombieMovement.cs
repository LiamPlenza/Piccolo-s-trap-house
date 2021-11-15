using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMovement : MonoBehaviour
{

    public PhotonView photonView;
    public Text PlayerNameText;
    public GameObject PlayerCamera;

    public CharacterController controller;

    public float speed;
    public float gravity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Animator animator;

    public GameObject player;


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
    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
          float distance = Vector3.Distance(transform.position, player.transform.position);
          if (distance <= 2.0f){
              player.GetComponent<CharacterMovementPresentacion>().reduceLife();
          }
          Attack();
      }
      if (photonView.isMine) {
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
            speed = 10f;
        }
        else
        {
            animator.SetBool("Running", false);
            speed = 8f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 2.0f){
                player.GetComponent<CharacterMovementPresentacion>().reduceLife();
            }
            Attack();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
