using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float speed; 

    // Basic movement script for test purposes
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
            transform.position += Vector3.forward * (speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position -= Vector3.forward * (speed * Time.deltaTime);

        }
        if(Input.GetKey(KeyCode.Q)) {
            transform.position -= Vector3.right * (speed * Time.deltaTime);

        }
        if(Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * (speed * Time.deltaTime);

        }
    }
}
