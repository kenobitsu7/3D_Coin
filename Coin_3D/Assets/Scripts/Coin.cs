using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Valeur de la pi�ce
    public int value;

    // R�f�rence � l'AudioManager pour jouer des effets sonores
    AudioManager audioManager;

    // M�thode appel�e lors de l'initialisation de l'objet
    private void Awake()
    {
        // Recherche de l'objet Audio (taggu� "Audio") et r�cup�ration du composant AudioManager
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // Faire tourner l'objet "Coin" autour de l'axe Y (rotation locale)
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }

    // M�thode appel�e lorsqu'un autre collider entre en collision avec celui de la pi�ce
    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet qui entre en collision est le joueur
        if (other.name == "Player")
        {
            // Jouer le son de la pi�ce collect�e via l'AudioManager
            audioManager.PlaySFX(audioManager.coin);

            // Ajouter la valeur de la pi�ce au score du jeu
            GameManager.Instance.Score += value;

            // D�truire l'objet (la pi�ce) apr�s qu'il ait �t� collect�
            Destroy(gameObject);
        }
    }
}
