using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3DManager : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject playButtonObjUI;
    public GameObject gameOverUI;

    [HideInInspector]
    public PlayButton playButton;
    [HideInInspector]
    public bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        playButton = playButtonObjUI.GetComponent<PlayButton>();
    }

    public void onDeath() {
        healthBar.SetActive(false);
        playButtonObjUI.SetActive(false);
        
        gameOverUI.SetActive(true);
        dead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.gameRunning) {
            playButtonObjUI.SetActive(false);
        }
    }
}
