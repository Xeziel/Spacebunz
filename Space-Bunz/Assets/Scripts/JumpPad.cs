using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad
{
    private float jumpForce;
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
    }

    public JumpPad(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        Debug.Log("Entered trigger");
        other.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, jumpForce));
    }
}
