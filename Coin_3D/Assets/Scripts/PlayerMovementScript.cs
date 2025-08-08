using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    // Variables publiques permettant de modifier les param�tres dans l'inspecteur Unity
    public float speed;             // Vitesse de d�placement
    public float rotationSpeed;     // Vitesse de rotation du joueur
    public float jumpSpeed;         // Force du saut

    // R�f�rences internes aux composants
    private Rigidbody rb;           // R�f�rence au Rigidbody du joueur
    public bool isGrounded;         // V�rifie si le joueur est au sol
    public float groundCheckDistance = 1;  // Distance pour v�rifier si le joueur est au sol
    public LayerMask groundLayer;  // Masque de couche pour d�tecter le sol
    private Transform camTransform; // R�f�rence � la cam�ra principale

    private Animator animator;      // R�f�rence � l'Animator pour les animations

    private Vector3 moveDirection;  // Direction du mouvement
    private float magnitude;        // Magnitude de la direction du mouvement (norme)

    // Start est appel� avant la premi�re image
    void Start()
    {
        // R�cup�re les composants n�cessaires
        rb = GetComponent<Rigidbody>();

        // R�cup�re la r�f�rence � la cam�ra principale
        camTransform = Camera.main.transform;

        // R�cup�re l'Animator de l'enfant (suppos� que le mod�le du joueur est un enfant de l'objet joueur)
        animator = GetComponentInChildren<Animator>();
    }

    // Update est appel� une fois par frame
    void Update()
    {
        // V�rifie si le joueur est au sol en envoyant un rayon vers le bas
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Appelle les m�thodes de mouvement et de saut
        Movement();
        Jump();
    }

    // FixedUpdate est appel� � un rythme fixe, utilis� pour les d�placements physiques
    private void FixedUpdate()
    {
        // Calcul du mouvement du joueur bas� sur la direction et la vitesse
        Vector3 move = moveDirection * magnitude * speed;

        // Applique la vitesse sur le Rigidbody, en gardant la v�locit� Y inchang�e (important pour sauter)
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    // G�re le mouvement du joueur
    private void Movement()
    {
        // R�cup�re les entr�es horizontales et verticales (WASD ou fl�ches)
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        // R�cup�re les directions avant et droite de la cam�ra
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Ignore les composantes verticales de la cam�ra (on veut uniquement les directions X/Z)
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalise les vecteurs pour �viter de trop acc�l�rer le mouvement
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calcule la direction du mouvement en fonction des entr�es et de la cam�ra
        moveDirection = (cameraForward * verticalMove + cameraRight * horizontalMove);

        // Calcule la magnitude du vecteur de mouvement
        magnitude = moveDirection.magnitude;

        // Limite la magnitude � 1 pour �viter une vitesse sup�rieure � celle attendue
        magnitude = Mathf.Clamp01(magnitude);

        // Met � jour l'animation en fonction de la vitesse du mouvement
        animator.SetFloat("ForwardSpeed", magnitude);

        // Si une direction de mouvement est d�tect�e, on fait tourner le joueur dans cette direction
        if (moveDirection != Vector3.zero)
        {
            // Cr�e une rotation visant la direction du mouvement
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);

            // Effectue la rotation de mani�re fluide en fonction de la vitesse de rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    // G�re le saut du joueur
    private void Jump()
    {
        // Remet � false la demande de saut si aucune entr�e n'est d�tect�e
        animator.SetBool("JumpRequested", false);

        // Si la touche de saut est press�e et que le joueur est au sol, on applique une force vers le haut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Applique une force d'impulsion pour faire sauter le joueur
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            // Active l'animation du saut
            animator.SetBool("JumpRequested", true);
        }

        // Met � jour l'�tat de l'animation selon si le joueur est au sol ou non
        animator.SetBool("isGrounded", isGrounded);
    }

    // Dessine un gizmo pour visualiser la port�e de la d�tection du sol
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        // Dessine une ligne verticale allant du joueur vers le bas pour indiquer la port�e de la d�tection du sol
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
