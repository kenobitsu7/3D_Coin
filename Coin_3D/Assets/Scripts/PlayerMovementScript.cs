using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private CharacterController conn;
    public bool isGrounded;
    private Transform camTransform;

    
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        conn = GetComponent<CharacterController>();
        camTransform = Camera.main.transform;
        
        animator = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward*verticalMove+cameraRight*horizontalMove);
        
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        animator.SetFloat("ForwardSpeed",magnitude);

        conn.SimpleMove(moveDirection * magnitude * speed);

        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            ySpeed = -0.5f;
        }

        Vector3 vel = moveDirection * magnitude;
        vel.y = ySpeed;
        
        conn.Move(vel * Time.deltaTime);

        if (conn.isGrounded)
        {
            ySpeed = -0.5f;
            animator.SetBool("JumpRequested", false);
            isGrounded = true;
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("JumpRequested", true);

                ySpeed = jumpSpeed;
                isGrounded = false;
            }

            animator.SetBool("isGrounded",isGrounded);
        }

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Coin" )
        {
            Score.scoreCount += 1;
        }
    }
}
