using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar
{
    private Slider slider = GameObject.Find("Health bar").GetComponent<Slider>();
    private int maxHealth;
    private int currentHealth;

    public HealthBar (int maxHealth) 
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public int MaxHealth 
    {
        get { return maxHealth; } 
        set { maxHealth = value;}
    }

    public int CurrentHealth 
    {
        get { return currentHealth;}
        set { currentHealth = value;}
    }

    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public  void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadSceneAsync("EndGame");
        }
    }

}
