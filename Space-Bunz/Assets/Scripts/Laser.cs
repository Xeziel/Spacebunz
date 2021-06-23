using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timer;

    [SerializeField]
    private bool timed = false;
    [SerializeField]
    private float onTime;
    [SerializeField]
    private float downTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player2DController>().healthBar.TakeDamage(HealthBar.Hitpoints.Low);
        }

        if (other.name == "box")
        {
            GameObject.Find("Player").GetComponent<Player2DController>().playerPush.Release();
            other.gameObject.SetActive(false);           
            GameObject.Find("Player").GetComponent<Player2DController>().player.JumpForce = Speed.Jmp.high;
        }       
    }

    private void Awake()
    {
        if (timed)
        {
            timer = onTime;
        }
    }

    private void FixedUpdate()
    {
        if (timed)
        {
            timer -= Time.fixedDeltaTime;

            if (timer < 0)
            {
                GetComponent<Animator>().SetBool("turnedOff", true);
                foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
                {
                    c.enabled = false;
                }
            }

            if (timer < -downTime)
            {
                GetComponent<Animator>().SetBool("turnedOff", false);
                foreach (BoxCollider2D c in GetComponents<BoxCollider2D>())
                {
                    c.enabled = true;
                }

                timer = onTime;
            }
        }
    }


}
