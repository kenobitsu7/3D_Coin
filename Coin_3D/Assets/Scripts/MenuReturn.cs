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
        }
    }
}
