using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float arrivalThreshold = 1.0f;
    [SerializeField] private float chaseRange = 3.0f;
    [SerializeField] private Transform player;
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private bool isChasing;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            if (!isChasing)
            {
                isChasing = true;
            }

            agent.SetDestination(player.position);

        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
            if (agent.pathPending == false && agent.remainingDistance < arrivalThreshold)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
        
    }
}
