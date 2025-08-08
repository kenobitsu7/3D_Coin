using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  

public class EnemyKill : MonoBehaviour
{
    // Cette méthode est appelée lorsqu'un autre objet entre en collision avec le Collider de cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Si l'objet qui entre en collision a le tag "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Récupère le composant "EnemyController" de l'objet touché
            var enemy = other.gameObject.GetComponent<EnemyController>();

            // Augmente le compteur des ennemis tués dans le GameManager
            GameManager.Instance.KillCount++;

            // Appelle la méthode Kill() de l'ennemi pour le tuer
            enemy.Kill();
        }
    }
}
