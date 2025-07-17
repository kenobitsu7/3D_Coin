using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform[] wayspoints;
    public float speed = 3f;
    private int currentWaypointIndex = 0;
    private Rigidbody rb;

    public float detectionRange = 10f;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerInRange())
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
        
    }

    void Patrol()
    {
        if (wayspoints.Length == 0) return;

        Transform targetWaypoint = wayspoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % wayspoints.Length;
        } 
    }

    bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime );
    }

    
}
