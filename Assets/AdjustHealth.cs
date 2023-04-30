using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustHealth : MonoBehaviour
{
    public Image healthBar; //place the UI image that represents the players health here (dont forget to set image to fillamount)
    public float scale;
    public Slider healthSlider;
    public int maxHealth; //the players maximum health
    public int health; //the players health value

    void Start() {
        maxHealth = GameManager.Instance.maxHealth;
        scale = maxHealth / 100f;
    }

    public void UpdateHealth () //always try not to use the "Update" function
    {
        health = GameManager.Instance.currentHealth;
        scale = health / 100f;
        transform.localScale = new Vector3(scale, 1, 1);

    }

    void Update() {
        if(GameManager.Instance.currentHealth > 0)
            UpdateHealth();
    }
}
