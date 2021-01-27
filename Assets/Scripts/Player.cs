using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Dictionary<string, int> entityTouched = new Dictionary<string, int>() {{"Enemy", 0}, {"Human", 0}};
    public int health, healthLossOnHit;
    public GameObject UIManager;
    [HideInInspector]
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        HealthBar.setHealthBarInfo(health, maxHealth);
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }
    
    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) {
        Debug.Log("Load callback");
        if(scene.name == "mainScene"){
            HealthBar.setHealthBarInfo(health, maxHealth);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            onDeath();
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject colObject = other.gameObject;
        
        if(colObject.tag == "Enemy" || colObject.tag == "Human"){
            Destroy(colObject);
            entityTouched[colObject.tag]++;
        }

        if(colObject.tag == "Enemy" && health > 0) {
            onHit();
        }
    }

    private void onHit() {
        health -= healthLossOnHit;
        HealthBar.setHealthBarInfo(health, maxHealth);
        // Debug.Log("Player lost " + healthLossOnHit + ", " + health + " remaining");
    }

    private void onDeath() {
        // Debug.Log("Death");
        UIManager.GetComponent<UIManager>().onDeath();
    }
}
