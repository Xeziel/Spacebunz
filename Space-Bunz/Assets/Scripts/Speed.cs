using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    private float movementSpeed;
    private float jumpForce;

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
            MovementSpeed = value;
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
            JumpForce = value;
        }
    }
}

