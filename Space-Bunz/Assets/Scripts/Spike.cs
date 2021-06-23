using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike
{

    private Dmg damage;
    private GameObject player = GameObject.Find("Player");

    public enum Dmg
    {
        low = 1,
        medium,
        high
    }

    public Spike (Dmg damage) 
    {
        this.damage = damage;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponent<Player2DController>().healthBar.TakeDamage(HealthBar.Hitpoints.Low);
            Debug.Log("Ouchies!");
        }

        if (other.gameObject.name == "box")
        {
            player.GetComponent<Player2DController>().playerPush.Release();
            other.gameObject.SetActive(false);           
            player.GetComponent<Player2DController>().player.JumpForce = Speed.Jmp.high;
        }
    }


}
