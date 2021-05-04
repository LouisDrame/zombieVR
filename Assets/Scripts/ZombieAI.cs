using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshAgent agent;
    public float speed = 0.3f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = speed;
        if (target != null) {
            agent.SetDestination(target.position);
        }
    }


    // Update is called once per frame
    void FixedUpdate() {
        Vector3 nextPosition = agent.nextPosition;
        Vector3 correctPosition = new  Vector3(nextPosition.x, 0, nextPosition.z);
        transform.position = correctPosition;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Zombies/footstep", GetComponent<Transform>().position);
    }

    public void setTarget(Transform newTarget) {
        target = newTarget;
    }
}
