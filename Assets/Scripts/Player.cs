using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Dictionary<string, int> entityTouched = new Dictionary<string, int>() {{"Enemy", 0}, {"Human", 0}};

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
            entityTouched[colObject.tag]++;
        }
    }
}
