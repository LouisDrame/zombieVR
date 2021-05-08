using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public bool gameRunning;

    // Start is called before the first frame update
    void Start()
    {
        gameRunning = false;
    }

    private void OnTriggerEnter(Collider colObject) {
        gameRunning = true;
    }
}
