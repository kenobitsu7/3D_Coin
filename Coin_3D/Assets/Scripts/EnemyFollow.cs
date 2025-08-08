using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // D�claration d'une r�f�rence au composant NavMeshAgent de l'ennemi
    public NavMeshAgent enemy;

    // D�claration d'une r�f�rence � la position du joueur
    public Transform player;

    // La m�thode Update est appel�e � chaque frame
    void Update()
    {
        // On met � jour la destination de l'ennemi pour qu'il suive le joueur
        enemy.SetDestination(player.position);
    }
}
