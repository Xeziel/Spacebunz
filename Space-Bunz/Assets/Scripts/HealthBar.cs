using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar
{
    private Slider slider = GameObject.Find("Health bar").GetComponent<Slider>();
    private Hitpoints maxHealth;
    private Hitpoints currentHealth;


    public HealthBar (Hitpoints maxHealth) 
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public HealthBar()
    {
        maxHealth = Hitpoints.High;
        currentHealth = Hitpoints.High;
    }

    public Hitpoints MaxHealth 
    {
        get { return maxHealth; } 
        set { maxHealth = value;}
    }

    public Hitpoints CurrentHealth 
    {
        get { return currentHealth;}
        set { currentHealth = value;}
    }

    public enum Hitpoints
    {
        Low = 1,
        Medium,
        High
    }

    public void SetMaxHealth (Hitpoints health)
    {
        slider.maxValue = (int)health;
        slider.value = (int)health;
    }

    public void SetHealth(Hitpoints health)
    {
        slider.value = (int)health;
    }

    public void TakeDamage(Hitpoints damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadSceneAsync("EndGame");
        }
    }

}
