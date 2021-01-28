using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject healthBar, gameOverUI;
    private bool dead = false;
    // Start is called before the first frame update
    public void onDeath() {
        healthBar.SetActive(false);
        gameOverUI.SetActive(true);
        // Time.timeScale = 0f;
        dead = true;
    }

    private void Update() {
        if(Input.GetKeyDown("space") && dead){
            SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
        }
    }
}
