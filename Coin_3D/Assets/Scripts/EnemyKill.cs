using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  

public class EnemyKill : MonoBehaviour
{
    // Cette m�thode est appel�e lorsqu'un autre objet entre en collision avec le Collider de cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Si l'objet qui entre en collision a le tag "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // R�cup�re le composant "EnemyController" de l'objet touch�
            var enemy = other.gameObject.GetComponent<EnemyController>();

            // Augmente le compteur des ennemis tu�s dans le GameManager
            GameManager.Instance.KillCount++;

            // Appelle la m�thode Kill() de l'ennemi pour le tuer
            enemy.Kill();
        }
    }
}
