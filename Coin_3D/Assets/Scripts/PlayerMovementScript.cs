using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    // Variables publiques permettant de modifier les paramètres dans l'inspecteur Unity
    public float speed;             // Vitesse de déplacement
    public float rotationSpeed;     // Vitesse de rotation du joueur
    public float jumpSpeed;         // Force du saut

    // Références internes aux composants
    private Rigidbody rb;           // Référence au Rigidbody du joueur
    public bool isGrounded;         // Vérifie si le joueur est au sol
    public float groundCheckDistance = 1;  // Distance pour vérifier si le joueur est au sol
    public LayerMask groundLayer;  // Masque de couche pour détecter le sol
    private Transform camTransform; // Référence à la caméra principale

    private Animator animator;      // Référence à l'Animator pour les animations

    private Vector3 moveDirection;  // Direction du mouvement
    private float magnitude;        // Magnitude de la direction du mouvement (norme)

    // Start est appelé avant la première image
    void Start()
    {
        // Récupère les composants nécessaires
        rb = GetComponent<Rigidbody>();

        // Récupère la référence à la caméra principale
        camTransform = Camera.main.transform;

        // Récupère l'Animator de l'enfant (supposé que le modèle du joueur est un enfant de l'objet joueur)
        animator = GetComponentInChildren<Animator>();
    }

    // Update est appelé une fois par frame
    void Update()
    {
        // Vérifie si le joueur est au sol en envoyant un rayon vers le bas
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Appelle les méthodes de mouvement et de saut
        Movement();
        Jump();
    }

    // FixedUpdate est appelé à un rythme fixe, utilisé pour les déplacements physiques
    private void FixedUpdate()
    {
        // Calcul du mouvement du joueur basé sur la direction et la vitesse
        Vector3 move = moveDirection * magnitude * speed;

        // Applique la vitesse sur le Rigidbody, en gardant la vélocité Y inchangée (important pour sauter)
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    // Gère le mouvement du joueur
    private void Movement()
    {
        // Récupère les entrées horizontales et verticales (WASD ou flèches)
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        // Récupère les directions avant et droite de la caméra
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Ignore les composantes verticales de la caméra (on veut uniquement les directions X/Z)
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalise les vecteurs pour éviter de trop accélérer le mouvement
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calcule la direction du mouvement en fonction des entrées et de la caméra
        moveDirection = (cameraForward * verticalMove + cameraRight * horizontalMove);

        // Calcule la magnitude du vecteur de mouvement
        magnitude = moveDirection.magnitude;

        // Limite la magnitude à 1 pour éviter une vitesse supérieure à celle attendue
        magnitude = Mathf.Clamp01(magnitude);

        // Met à jour l'animation en fonction de la vitesse du mouvement
        animator.SetFloat("ForwardSpeed", magnitude);

        // Si une direction de mouvement est détectée, on fait tourner le joueur dans cette direction
        if (moveDirection != Vector3.zero)
        {
            // Crée une rotation visant la direction du mouvement
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);

            // Effectue la rotation de manière fluide en fonction de la vitesse de rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    // Gère le saut du joueur
    private void Jump()
    {
        // Remet à false la demande de saut si aucune entrée n'est détectée
        animator.SetBool("JumpRequested", false);

        // Si la touche de saut est pressée et que le joueur est au sol, on applique une force vers le haut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Applique une force d'impulsion pour faire sauter le joueur
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            // Active l'animation du saut
            animator.SetBool("JumpRequested", true);
        }

        // Met à jour l'état de l'animation selon si le joueur est au sol ou non
        animator.SetBool("isGrounded", isGrounded);
    }

    // Dessine un gizmo pour visualiser la portée de la détection du sol
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        // Dessine une ligne verticale allant du joueur vers le bas pour indiquer la portée de la détection du sol
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
