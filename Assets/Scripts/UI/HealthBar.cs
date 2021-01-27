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
        healthText = GetComponentsInChildren<Text>()[0];
        healthBarImage = GetComponentsInChildren<Image>()[0];
        healthBarImage.color = Color.red;
    }

    public static void setHealthBarInfo(int currentHealth, int maxHealth) {
        healthBarImage.fillAmount =(float)currentHealth / maxHealth;
        Debug.Log(maxHealth);
        healthText.text = currentHealth + " / " + maxHealth;
    }
}
