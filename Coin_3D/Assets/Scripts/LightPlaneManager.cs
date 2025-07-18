using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlaneManager : MonoBehaviour
{
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private GameObject[] lights;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            directionalLight.SetActive(false);
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            directionalLight.SetActive(true);
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
