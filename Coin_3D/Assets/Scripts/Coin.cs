using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Valeur de la pièce
    public int value;

    // Référence à l'AudioManager pour jouer des effets sonores
    AudioManager audioManager;

    // Méthode appelée lors de l'initialisation de l'objet
    private void Awake()
    {
        // Recherche de l'objet Audio (taggué "Audio") et récupération du composant AudioManager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Faire tourner l'objet "Coin" autour de l'axe Y (rotation locale)
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }

    // Méthode appelée lorsqu'un autre collider entre en collision avec celui de la pièce
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet qui entre en collision est le joueur
        if (other.name == "Player")
        {
            // Jouer le son de la pièce collectée via l'AudioManager
            audioManager.PlaySFX(audioManager.coin);

            // Ajouter la valeur de la pièce au score du jeu
            GameManager.Instance.Score += value;

            // Détruire l'objet (la pièce) après qu'il ait été collecté
            Destroy(gameObject);
        }
    }
}
