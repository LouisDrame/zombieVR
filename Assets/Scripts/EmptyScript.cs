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

    private void OnCollisionEnter(Collision other) {
        GameObject colObject = other.gameObject;
        
        if(colObject.tag == "Enemy" || colObject.tag == "Human"){
            Destroy(colObject);
            entityKilled[colObject.tag]++;
        }
    }
}
