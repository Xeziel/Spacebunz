using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    internal Player2DController player2DController = null;

    private float movementSpeed = 5;

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

    private float jumpForce = 4;

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

