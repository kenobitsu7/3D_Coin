using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayTime;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTime(GameManager.Instance.Time);
    }

    void DisplayTime(float timeToDisplay)
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        displayTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
