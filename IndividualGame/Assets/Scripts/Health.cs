using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    Image healthBar;
    float maxHealth = 100f;
    public static float health;
    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

// Update is called once per frame
void Update () {
        
    healthBar.fillAmount = health / maxHealth;
        health -= 0.1f;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0f)
        {
            health = 0f;
        }
    }
}