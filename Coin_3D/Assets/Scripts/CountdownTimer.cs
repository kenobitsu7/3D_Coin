using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public TextMeshProUGUI timerText;
    public float timeValue = 90;

    public GameObject GameOver;
        
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.TimerIsStop)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            DisplayTime(timeValue);
        }
        
    }
    void DisplayTime(float timeToDisplay)
    { 
        if (timeToDisplay < 0)
        { 
            timeToDisplay = 0;

            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;

            audioManager.StopMusic();
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
