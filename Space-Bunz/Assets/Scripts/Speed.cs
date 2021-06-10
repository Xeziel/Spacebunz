using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    private float movementSpeed;
    private float jumpForce;
    private float wallForce;
    private float wallHeight;

    public enum Spd
    {
        slowed = 2,
        normal = 5,
        fast= 8
    }

    public enum Jmp
    {
        low = 1,
        normal = 4,
        high = 8,
        veryhigh = 15

    }

    public Speed (Spd movementspeed, Jmp jumpforce, Spd wallforce, Jmp wallheight)
    {
        movementSpeed = (float)movementspeed;
        jumpForce = (float)jumpforce;
        wallForce = (float)wallforce;
        wallHeight = (float)wallheight;

    }

    

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }

    

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

    public float WallForce { get; set; }
    public float WallHeight { get; set; }
}

