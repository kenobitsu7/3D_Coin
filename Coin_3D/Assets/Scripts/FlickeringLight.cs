using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float waitingTime;
    [SerializeField] private float defaultIntensity;
    [SerializeField] private float targetIntensity;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flickering());
    }

    IEnumerator Flickering()
    {
        while (true)
        {
            if (_light.intensity == defaultIntensity)
            {
                _light.intensity = targetIntensity;
            }
            else if (_light.intensity == targetIntensity)
            {
                _light.intensity = defaultIntensity;
            }
            yield return new WaitForSeconds(waitingTime);
        }
            
    }
    
}
