using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Déclaration d'une référence au composant NavMeshAgent de l'ennemi
    public NavMeshAgent enemy;

    // Déclaration d'une référence à la position du joueur
    public Transform player;

    // La méthode Update est appelée à chaque frame
    void Update()
    {
        // On met à jour la destination de l'ennemi pour qu'il suive le joueur
        enemy.SetDestination(player.position);
    }
}
