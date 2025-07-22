using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
          
            var enemy = other.gameObject.GetComponent<EnemyController>();         
            enemy.Kill();
            
        }
    }
}
