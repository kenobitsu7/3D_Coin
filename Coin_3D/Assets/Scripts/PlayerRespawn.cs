using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private HealthManager healthManager;
    [SerializeField] private CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DeathCollider"))
        {

            characterController.enabled = false;

            healthManager.ManageHealth(-1);

            transform.position = new Vector3(0.01f, 0.951f, 0.04f);

            characterController.enabled = true;

        }
    }   
}
