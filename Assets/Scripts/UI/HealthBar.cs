using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Image healthBarImage;
    public static Text healthText;

    void Start()
    {
        init();
    }

    private static void init() {
        if (healthText == null && healthBarImage == null) {
            healthText = GameObject.Find("HealthBar").GetComponentsInChildren<Text>()[0];
            healthBarImage =  GameObject.Find("HealthBar").GetComponentsInChildren<Image>()[0];
            healthBarImage.color = Color.red;
        }
    }

    public static void setHealthBarInfo(int currentHealth, int maxHealth) {
        init();
        healthBarImage.fillAmount =(float)currentHealth / maxHealth;
        healthText.text = currentHealth + " / " + maxHealth;
    }
}
