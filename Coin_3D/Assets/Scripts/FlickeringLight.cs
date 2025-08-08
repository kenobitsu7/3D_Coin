using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    // D�claration d'une r�f�rence au composant Light qui sera assign� dans l'inspecteur
    [SerializeField] private Light _light;

    // Temps d'attente entre les changements d'intensit� de la lumi�re (en secondes)
    [SerializeField] private float waitingTime;

    // Intensit� par d�faut de la lumi�re (quand elle n'est pas en train de clignoter)
    [SerializeField] private float defaultIntensity;

    // Intensit� cible de la lumi�re (quand elle est "allum�e" pendant le clignotement)
    [SerializeField] private float targetIntensity;

    // Cette m�thode est appel�e au d�marrage de l'ex�cution du jeu
    void Start()
    {
        // D�marre la coroutine qui fait le clignotement de la lumi�re
        StartCoroutine(Flickering());
    }

    // Coroutine qui g�re le clignotement de la lumi�re
    IEnumerator Flickering()
    {
        // Cette boucle infinie fait clignoter la lumi�re jusqu'� ce que le jeu se termine
        while (true)
        {
            // Si l'intensit� actuelle de la lumi�re est �gale � l'intensit� par d�faut
            if (_light.intensity == defaultIntensity)
            {
                // On change l'intensit� de la lumi�re � l'intensit� cible (celle qui repr�sente la lumi�re allum�e)
                _light.intensity = targetIntensity;
            }
            // Si l'intensit� actuelle est �gale � l'intensit� cible
            else if (_light.intensity == targetIntensity)
            {
                // On remet l'intensit� � la valeur par d�faut (lorsque la lumi�re est �teinte ou faible)
                _light.intensity = defaultIntensity;
            }

            // On attend un certain temps (waitingTime) avant de changer � nouveau l'intensit�
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
