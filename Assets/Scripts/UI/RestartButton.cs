using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider colObject) {
        SceneManager.LoadScene("zombieScene", LoadSceneMode.Single);
    }
}
