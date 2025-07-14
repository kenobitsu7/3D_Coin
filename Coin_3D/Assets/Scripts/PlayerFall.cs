using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{

    // [SerializeField] private HealthManager healthManager;
    // [SerializeField] private CharacterController characterController;
    public GameObject Player;
    public GameObject GameOver, heart1, heart2, heart3;

    private void OnTriggerEnter(Collider other)
    {
        /*
        
        if(other.gameObject.CompareTag("DeathCollider"))
        {

            characterController.enabled = false;

            healthManager.ManageHealth(-1);

            transform.position = new Vector3(0.01f, 0.951f, 0.04f);

            characterController.enabled = true;

        }

        */
         
        if (other.gameObject.CompareTag("DeathCollider"))
        {

            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);

            Player.gameObject.SetActive(false);

            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;

        }

    }   
}
