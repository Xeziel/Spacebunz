using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike
{

    private int damage;

    public Spike (int damage) 
    {
        this.damage = damage;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Player2DController>().healthBar.TakeDamage(damage);
        Debug.Log("Ouchies!");
    }


}
