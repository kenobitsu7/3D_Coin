using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Kill()
    {
        Destroy(gameObject);       
    }
}
