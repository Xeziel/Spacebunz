using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    private float movementSpeed;
    private float jumpForce;

    enum Spd
    {
        slowed = 2,
        normal = 5
    }

    enum Jmp
    {
        low = 1,
        normal = 4,
        high = 8,
        veryhigh = 15

    }

    public Speed (float movementspeed, float jumpforce)
    {
        movementSpeed = movementspeed;
        jumpForce = jumpforce;
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
}

