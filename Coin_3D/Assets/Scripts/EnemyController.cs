using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Déclaration de la classe "EnemyController", qui gère le comportement des ennemis dans le jeu.
public class EnemyController : MonoBehaviour
{
    // Méthode publique Kill() qui est utilisée pour détruire l'ennemi.
    public void Kill()
    {
        // Détruire l'objet auquel ce script est attaché (l'ennemi).
        Destroy(gameObject);
    }
}
