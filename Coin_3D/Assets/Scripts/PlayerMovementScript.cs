using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    
    private Rigidbody rb;
    public bool isGrounded;
    public float groundCheckDistance = 1;
    public LayerMask groundLayer;
    private Transform camTransform;

    
    private Animator animator;

    private Vector3 moveDirection;

    private float magnitude;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
        
        animator = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        Movement();
        Jump();
    }

    private void FixedUpdate()
    {
        Vector3 move = moveDirection * magnitude * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
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

        moveDirection = (cameraForward*verticalMove+cameraRight*horizontalMove);
        
        magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        animator.SetFloat("ForwardSpeed",magnitude);
     
       
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }


    private void Jump()
    {
        animator.SetBool("JumpRequested", false);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            animator.SetBool("JumpRequested", true);
        }

        animator.SetBool("isGrounded", isGrounded);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
