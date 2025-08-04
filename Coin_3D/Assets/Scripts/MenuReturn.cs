using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            SceneManager.LoadScene("MainMenu");

            GameManager.Instance.Score = 0;
            GameManager.Instance.KillCount = 0;

            GameManager.Instance.TimerIsStop = false;
            GameManager.Instance.Time = 90f;
        }
    }
}
