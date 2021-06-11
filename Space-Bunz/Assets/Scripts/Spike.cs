using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike
{

    private int damage;
    GameObject player = GameObject.Find("Player");

    public Spike (int damage) 
    {
        this.damage = damage;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.GetComponent<Player2DController>().healthBar.TakeDamage(damage);
            Debug.Log("Ouchies!");
        }

        if (other.gameObject.name == "box")
        {
            Object.Destroy(other.gameObject);
            player.GetComponent<Player2DController>().player.JumpForce = Speed.Jmp.high;
        }
    }


}
