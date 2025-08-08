using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    // Déclaration des variables sérialisées accessibles depuis l'inspecteur Unity
    [SerializeField] private Transform[] waypoints; // Tableau des points de passage que l'ennemi va suivre
    [SerializeField] private float arrivalThreshold = 1.0f; // Distance à laquelle l'ennemi considère qu'il a atteint un point
    [SerializeField] private float chaseRange = 3.0f; // Distance à partir de laquelle l'ennemi commence à poursuivre le joueur
    [SerializeField] private Transform player; // Référence au joueur
    private int currentWaypointIndex = 0; // L'index du point de passage actuel
    private NavMeshAgent agent; // Référence à l'agent de navigation
    private bool isChasing; // Booléen pour savoir si l'ennemi est en train de poursuivre le joueur

    // Méthode d'initialisation appelée au début du jeu
    void Start()
    {
        // Récupère le composant NavMeshAgent attaché à l'objet
        agent = GetComponent<NavMeshAgent>();

        // Si des points de passage sont définis, on définit la destination du NavMeshAgent sur le premier point
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Calcule la distance entre l'ennemi et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans la plage de poursuite
        if (distanceToPlayer <= chaseRange)
        {
            // Si l'ennemi n'est pas déjà en train de poursuivre, on commence la poursuite
            if (!isChasing)
            {
                isChasing = true;
            }

            // L'ennemi se dirige vers la position du joueur
            agent.SetDestination(player.position);
        }
        else
        {
            // Si l'ennemi n'est plus en train de poursuivre le joueur
            if (isChasing)
            {
                isChasing = false;
                // L'ennemi reprend son parcours de patrouille, se dirige vers le point de passage actuel
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }

            // Si l'ennemi a atteint son point de passage actuel ou qu'il est très proche
            if (agent.pathPending == false && agent.remainingDistance < arrivalThreshold)
            {
                // Passe au point de passage suivant (en boucle)
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                // Définit la nouvelle destination du NavMeshAgent
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}
