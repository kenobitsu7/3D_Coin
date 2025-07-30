using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float strength = 10f;
    [SerializeField] private float cooldown = 0.2f;
    private float lastKnockbackTime = -Mathf.Infinity;
    public void ApplyKnockback (Vector3 direction)
    {
        if(Time.time - lastKnockbackTime < cooldown)
        {
            return;
        }

        direction.y = 0f;
        rb.AddForce(direction.normalized*strength,ForceMode.Impulse);
        lastKnockbackTime = Time.time;
    }       
}
