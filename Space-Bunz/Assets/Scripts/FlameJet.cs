using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameJet
{

    private float maxtime;
    private float timer;
    private Animator animator;
    private bool shooting = false;
    private float cooldown;
    private Collider2D triggerarea;
    
    // Start is called before the first frame update
    public FlameJet( Animator animator, Collider2D collider)
    {

        maxtime = 5f;
        timer = 5f;
        cooldown = 5f;
        this.animator = animator;
        triggerarea = collider;
    }

    public FlameJet(float maxtime, float cooldown, Animator animator, Collider2D collider)
    {
        this.maxtime = maxtime;
        timer = maxtime;
        this.cooldown = cooldown;
        this.animator = animator;
        triggerarea = collider;
    }

    private void RunTimer()
    {
        timer -= Time.fixedDeltaTime;

        if (timer < -cooldown)
        {
            timer = maxtime;
        }

        if (timer > 0)
        {
            shooting = true;
        } else
        {
            shooting = false;
        }

        if (shooting)
        {
            animator.SetBool("isFiring", true);
            if (timer < 4.5f && timer > 0)
            {
                triggerarea.enabled = true;
            }
        } else
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
            other.GetComponent<Player2DController>().healthBar.TakeDamage(1);
        }
    }

}
