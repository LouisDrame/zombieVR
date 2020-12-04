using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementController : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;

    // Update is called once per frame
    void FixedUpdate() {
        agent.SetDestination(player.position);
    }
}
