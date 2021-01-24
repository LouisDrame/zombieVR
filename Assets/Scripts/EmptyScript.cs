using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyScript : MonoBehaviour
{
    Dictionary<string, int> entityKilled = new Dictionary<string, int>() {{"Enemy", 0}, {"Human", 0}};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        GameObject colObject = other.gameObject;
        
        if(colObject.tag == "Enemy" || colObject.tag == "Human"){
            Destroy(colObject);
            entityKilled[colObject.tag]++;
            if(colObject.tag == "Enemy")
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Zombies/Zombie Hurt", GetComponent<Transform>().position);
            } else if (colObject.tag == "Human")
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Humans/Human ded", GetComponent<Transform>().position);
            }
        }
    }
}
