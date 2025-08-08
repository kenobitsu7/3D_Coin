using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlaneManager : MonoBehaviour
{
    // R�f�rence � la lumi�re directionnelle dans la sc�ne (par exemple, lumi�re principale)
    [SerializeField] private GameObject directionalLight;

    // Tableau contenant les lumi�res suppl�mentaires � activer/d�sactiver
    [SerializeField] private GameObject[] lights;

    // Cette m�thode est appel�e lorsqu'un autre objet entre en collision avec le trigger
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // D�sactive la lumi�re directionnelle (par exemple, pour simuler un changement d'�clairage)
            directionalLight.SetActive(false);

            // Active toutes les lumi�res suppl�mentaires dans le tableau "lights"
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }

    // Cette m�thode est appel�e lorsqu'un autre objet quitte la collision avec le trigger
    private void OnTriggerExit(Collider other)
    {
        // V�rifie si l'objet qui quitte la zone est le joueur
        if (other.CompareTag("Player"))
        {
            // R�active la lumi�re directionnelle (restaure l'�clairage original)
            directionalLight.SetActive(true);

            // D�sactive toutes les lumi�res suppl�mentaires dans le tableau "lights"
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
