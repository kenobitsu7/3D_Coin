using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int sceneBuildIndex;
    public CountdownTimer countdownTimer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {    
            GameManager.Instance.TimerIsStop = true;
            GameManager.Instance.Time = countdownTimer.timeValue;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
