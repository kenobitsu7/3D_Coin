using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private HealthManager healthManager;   
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
 
            healthManager.ManageHealth(-damage);
            Vector3 dir = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<PlayerKnockback>()?.ApplyKnockback(dir);

        }
    }
}
