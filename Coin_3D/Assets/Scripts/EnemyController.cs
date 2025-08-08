using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// D�claration de la classe "EnemyController", qui g�re le comportement des ennemis dans le jeu.
public class EnemyController : MonoBehaviour
{
    // M�thode publique Kill() qui est utilis�e pour d�truire l'ennemi.
    public void Kill()
    {
        // D�truire l'objet auquel ce script est attach� (l'ennemi).
        Destroy(gameObject);
    }
}
