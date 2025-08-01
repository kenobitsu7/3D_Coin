using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    public void RestartLevel()
    {
        Time.timeScale = 1;
        healthManager.ManageHealth(3);
        SceneManager.LoadScene("Game");

        GameManager.Instance.Score = 0;
        GameManager.Instance.KillCount = 0;
    }
}
