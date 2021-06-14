using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed
{
    private Spd movementSpeed;
    private Jmp jumpForce;
    private Spd wallForce;
    private Jmp wallHeight;

    public enum Spd
    {
        slowed = 2,
        normal = 5,
        fast= 8
    }

    public enum Jmp
    {
        low = 2,
        normal = 4,
        high = 8,
        veryhigh = 15
    }

    public Speed (Spd movementspeed, Jmp jumpforce, Spd wallforce, Jmp wallheight)
    {
        movementSpeed = movementspeed;
        jumpForce = jumpforce;
        wallForce = wallforce;
        wallHeight = wallheight;

    }

    public Speed (Spd movementspeed)
    {
        movementSpeed = movementspeed;
        jumpForce = 0;
        wallForce = 0;
        wallHeight = 0;
    }

    

    public Spd MovementSpeed
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

    

    public Jmp JumpForce
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

    public Spd WallForce {
        get 
        {
            return wallForce;
        } 
        set
        {
            wallForce = value;
        }
    }

    public Jmp WallHeight
    {
        get
        {
            return wallHeight;
        }
        set
        {
            wallHeight = value;
        }
    }
}

