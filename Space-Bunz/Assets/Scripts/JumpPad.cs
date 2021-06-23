using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad
{
    private float jumpForce;
    private float angle;
    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
        set
        {
            jumpForce = value;
        }
    }

    public JumpPad()
    {
        jumpForce = 15f;
        angle = 0f;
    }

    public JumpPad(float jumpForce)
    {
        this.jumpForce = jumpForce;
        angle = 0f;
    }

    public JumpPad(float jumpForce, float angle)
    {
        this.jumpForce = jumpForce;
        this.angle = angle;
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        Debug.Log("Entered trigger");
        other.GetComponent<Rigidbody2D>().velocity = (new Vector2(angle, jumpForce));
    }
}
