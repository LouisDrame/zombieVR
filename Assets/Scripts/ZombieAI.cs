using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed = 10f;
    Vector3 destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * speed);
        }
    }

    public void setTarget(GameObject newTarget) {
        target = newTarget;
    }
}
