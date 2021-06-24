using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameJet
{
    [SerializeField]
    private float startTimer;
    [SerializeField]
    private float maxtime;
    [SerializeField]
    private float timer;
    private Animator animator;
    private bool shooting = false;
    [SerializeField]
    private float cooldown;
    private Collider2D triggerarea;
    
    // Start is called before the first frame update
    public FlameJet( Animator animator, Collider2D collider)
    {
        maxtime = 5f;
        timer = 5f;
        cooldown = 5f;
        startTimer = 0f;
        this.animator = animator;
        triggerarea = collider;
    }

    public FlameJet(float maxtime, float cooldown, Animator animator, Collider2D collider, float startTimer)
    {
        this.startTimer = startTimer;
        this.maxtime = maxtime;
        timer = maxtime;
        this.cooldown = cooldown;
        this.animator = animator;
        triggerarea = collider;
    }

    private void RunTimer()
    {
        if (startTimer > 0)
        {
            startTimer -= Time.fixedDeltaTime;
        }
        else
        {
            timer -= Time.fixedDeltaTime;

            if (timer < -cooldown)
            {
                timer = maxtime;
            }

            if (timer > 0)
            {
                shooting = true;
            }
            else
            {
                shooting = false;
            }
        }

            if (shooting)
            {
                animator.SetBool("isFiring", true);
                if (timer < 4.5f && timer > 0)
                {
                    triggerarea.enabled = true;
                }
            }
            else
            {
                animator.SetBool("isFiring", false);
                triggerarea.enabled = false;
            }
    }

    // Update is called once per frame
    public void Update()
    {
        RunTimer();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player2DController>().healthBar.TakeDamage(HealthBar.Hitpoints.Low);
        }

        if (other.name == "Box")
        {
            GameObject.Find("Player").GetComponent<Player2DController>().playerPush.Release();
            other.gameObject.SetActive(false);           
            GameObject.Find("Player").GetComponent<Player2DController>().player.JumpForce = Speed.Jmp.high;
        }
    }

}
