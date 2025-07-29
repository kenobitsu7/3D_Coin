using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
            
        if (other.gameObject.CompareTag("DeathCollider"))
        {

            healthManager.ManageHealth(-healthManager.Health);

            Player.gameObject.SetActive(false);

            Time.timeScale = 0;
        }

    }   
}
