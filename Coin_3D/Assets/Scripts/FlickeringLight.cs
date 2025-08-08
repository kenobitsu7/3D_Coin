using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    // Déclaration d'une référence au composant Light qui sera assigné dans l'inspecteur
    [SerializeField] private Light _light;

    // Temps d'attente entre les changements d'intensité de la lumière (en secondes)
    [SerializeField] private float waitingTime;

    // Intensité par défaut de la lumière (quand elle n'est pas en train de clignoter)
    [SerializeField] private float defaultIntensity;

    // Intensité cible de la lumière (quand elle est "allumée" pendant le clignotement)
    [SerializeField] private float targetIntensity;

    // Cette méthode est appelée au démarrage de l'exécution du jeu
    void Start()
    {
        // Démarre la coroutine qui fait le clignotement de la lumière
        StartCoroutine(Flickering());
    }

    // Coroutine qui gère le clignotement de la lumière
    IEnumerator Flickering()
    {
        // Cette boucle infinie fait clignoter la lumière jusqu'à ce que le jeu se termine
        while (true)
        {
            // Si l'intensité actuelle de la lumière est égale à l'intensité par défaut
            if (_light.intensity == defaultIntensity)
            {
                // On change l'intensité de la lumière à l'intensité cible (celle qui représente la lumière allumée)
                _light.intensity = targetIntensity;
            }
            // Si l'intensité actuelle est égale à l'intensité cible
            else if (_light.intensity == targetIntensity)
            {
                // On remet l'intensité à la valeur par défaut (lorsque la lumière est éteinte ou faible)
                _light.intensity = defaultIntensity;
            }

            // On attend un certain temps (waitingTime) avant de changer à nouveau l'intensité
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
