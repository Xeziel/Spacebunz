using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walljump
{

    private float wallJumpPower;
    private float wallJumpHeight;

    public Walljump(float wallJumpPower, float wallJumpHeight)
    {
        this.wallJumpHeight = wallJumpHeight;
        this.wallJumpPower = wallJumpPower;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "WalljumpArea")
        {
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(wallJumpPower * -Input.GetAxisRaw("Horizontal"), wallJumpHeight);
            }
        }
    }

}
