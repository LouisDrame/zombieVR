using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void FixedUpdate() {
        if (target != null) {
            agent.SetDestination(target.position);
        }
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Zombies/footstep", GetComponent<Transform>().position);
    }

    public void setTarget(Transform newTarget) {
        target = newTarget;
    }
}
