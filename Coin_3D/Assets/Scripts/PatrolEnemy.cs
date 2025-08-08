using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    // D�claration des variables s�rialis�es accessibles depuis l'inspecteur Unity
    [SerializeField] private Transform[] waypoints; // Tableau des points de passage que l'ennemi va suivre
    [SerializeField] private float arrivalThreshold = 1.0f; // Distance � laquelle l'ennemi consid�re qu'il a atteint un point
    [SerializeField] private float chaseRange = 3.0f; // Distance � partir de laquelle l'ennemi commence � poursuivre le joueur
    [SerializeField] private Transform player; // R�f�rence au joueur
    private int currentWaypointIndex = 0; // L'index du point de passage actuel
    private NavMeshAgent agent; // R�f�rence � l'agent de navigation
    private bool isChasing; // Bool�en pour savoir si l'ennemi est en train de poursuivre le joueur

    // M�thode d'initialisation appel�e au d�but du jeu
    void Start()
    {
        // R�cup�re le composant NavMeshAgent attach� � l'objet
        agent = GetComponent<NavMeshAgent>();

        // Si des points de passage sont d�finis, on d�finit la destination du NavMeshAgent sur le premier point
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // Calcule la distance entre l'ennemi et le joueur
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans la plage de poursuite
        if (distanceToPlayer <= chaseRange)
        {
            // Si l'ennemi n'est pas d�j� en train de poursuivre, on commence la poursuite
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

            // Si l'ennemi a atteint son point de passage actuel ou qu'il est tr�s proche
            if (agent.pathPending == false && agent.remainingDistance < arrivalThreshold)
            {
                // Passe au point de passage suivant (en boucle)
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                // D�finit la nouvelle destination du NavMeshAgent
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}
