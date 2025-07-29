using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;

    public void ExitLevel()
    {
        Time.timeScale = 1;
        healthManager.ManageHealth(3);
        SceneManager.LoadScene("MainMenu");

        GameManager.Instance.Score = 0;
        GameManager.Instance.KillCount = 0;
    }
}
