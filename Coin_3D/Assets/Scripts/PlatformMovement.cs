using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Vitesse de déplacement de la plateforme
    public float speed;

    // Point de départ pour la plateforme (index dans le tableau points)
    public int startingPoint;

    // Tableau des différents points de destination que la plateforme va traverser
    public Transform[] points;

    // Index pour parcourir les points
    private int i;

    // Start est appelé avant la première image (frame) du jeu
    void Start()
    {
        // Positionner la plateforme au point de départ spécifié dans le tableau points
        transform.position = points[startingPoint].position;
    }

    // Update est appelé une fois par frame
    void Update()
    {
        // Vérifier si la plateforme est proche du point actuel (si la distance est inférieure à 0.02)
        if (Vector3.Distance(transform.position, points[i].position) < 0.02f)
        {
            // Passer au prochain point dans le tableau
            i++;
            // Si on atteint la fin du tableau, recommencer depuis le début (boucle)
            if (i == points.Length)
            {
                i = 0;
            }
        }

        // Déplacer la plateforme vers le point cible en utilisant MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    // Méthode appelée lorsqu'un objet entre en collision avec la plateforme
    private void OnCollisionEnter(Collision collision)
    {
        // Attacher l'objet qui entre en collision à la plateforme (de sorte qu'il se déplace avec elle)
        collision.transform.SetParent(transform);
    }

    // Méthode appelée lorsqu'un objet quitte la collision avec la plateforme
    private void OnCollisionExit(Collision collision)
    {
        // Détacher l'objet de la plateforme afin qu'il ne la suive plus
        collision.transform.SetParent(null);
    }
}
