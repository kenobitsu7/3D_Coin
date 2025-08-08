using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Vitesse de d�placement de la plateforme
    public float speed;

    // Point de d�part pour la plateforme (index dans le tableau points)
    public int startingPoint;

    // Tableau des diff�rents points de destination que la plateforme va traverser
    public Transform[] points;

    // Index pour parcourir les points
    private int i;

    // Start est appel� avant la premi�re image (frame) du jeu
    void Start()
    {
        // Positionner la plateforme au point de d�part sp�cifi� dans le tableau points
        transform.position = points[startingPoint].position;
    }

    // Update est appel� une fois par frame
    void Update()
    {
        // V�rifier si la plateforme est proche du point actuel (si la distance est inf�rieure � 0.02)
        if (Vector3.Distance(transform.position, points[i].position) < 0.02f)
        {
            // Passer au prochain point dans le tableau
            i++;
            // Si on atteint la fin du tableau, recommencer depuis le d�but (boucle)
            if (i == points.Length)
            {
                i = 0;
            }
        }

        // D�placer la plateforme vers le point cible en utilisant MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    // M�thode appel�e lorsqu'un objet entre en collision avec la plateforme
    private void OnCollisionEnter(Collision collision)
    {
        // Attacher l'objet qui entre en collision � la plateforme (de sorte qu'il se d�place avec elle)
        collision.transform.SetParent(transform);
    }

    // M�thode appel�e lorsqu'un objet quitte la collision avec la plateforme
    private void OnCollisionExit(Collision collision)
    {
        // D�tacher l'objet de la plateforme afin qu'il ne la suive plus
        collision.transform.SetParent(null);
    }
}
